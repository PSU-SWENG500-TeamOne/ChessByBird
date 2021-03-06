﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Json;

namespace ChessByBird.TwitterProject
{
	public class OAuthInfo
	{
		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
		public string AccessToken { get; set; }
		public string AccessSecret { get; set; }
	}

	public class Tweet
	{
		public long Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public string UserName { get; set; }
		public string ScreenName { get; set; }
		public string Text { get; set; }
        public string inReplyToID { get; set; }
	}

	public class TinyTwitter
	{
		private readonly OAuthInfo oauth;

		public TinyTwitter(OAuthInfo oauth)
		{
			this.oauth = oauth;
		}

		public void UpdateStatus(string message)
		{
			new RequestBuilder(oauth, "POST", "http://api.twitter.com/1/statuses/update.xml")
				.AddParameter("status", message)
				.Execute();
		}

		public IEnumerable<Tweet> GetHomeTimeline(long? sinceId = null, int? count = 20)
		{
			return GetTimeline("http://api.twitter.com/1/statuses/home_timeline.xml", sinceId, count);
		}

		public IEnumerable<Tweet> GetMentions(long? sinceId = null, int? count = 20)
		{
			return GetTimeline("http://api.twitter.com/1/statuses/mentions.xml", sinceId, count);
		}

		public IEnumerable<Tweet> GetUserTimeline(long? sinceId = null, int? count = 20)
		{
			return GetTimeline("http://api.twitter.com/1/statuses/user_timeline.xml", sinceId, count);
		}

        public IEnumerable<Tweet> GetSpecificTweet(long tweetID)
        {
            string url = "https://api.twitter.com/1.1/statuses/show.json";
            var builder = new RequestBuilder(oauth, "GET", url);

            builder.AddParameter("id", tweetID.ToString());

            var response = builder.Execute();

            using (var stream = response.GetResponseStream())
            {
                var xml = XDocument.Load(new XmlTextReader(stream));
                return xml.Descendants("status")
                    .Select(x => new Tweet
                    {
                        Id = long.Parse(x.Element("id").Value),
                        CreatedAt = DateTime.ParseExact(x.Element("created_at").Value, "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture).ToLocalTime(),
                        UserName = x.Element("user").Element("name").Value,
                        ScreenName = x.Element("user").Element("screen_name").Value,
                        Text = x.Element("text").Value,
                        inReplyToID = x.Element("in_reply_to_status_id").Value
                    })
                    .ToArray();
            }
        }

		private IEnumerable<Tweet> GetTimeline(string url, long? sinceId, int? count)
		{
			var builder = new RequestBuilder(oauth, "GET", url);

			if (sinceId.HasValue)
				builder.AddParameter("since_id", sinceId.Value.ToString());

			if (count.HasValue)
				builder.AddParameter("count", count.Value.ToString());

			var response = builder.Execute();

			using (var stream = response.GetResponseStream())
			{
				var xml = XDocument.Load(new XmlTextReader(stream));
				return xml.Descendants("status")
					.Select(x => new Tweet
					{
						Id = long.Parse(x.Element("id").Value),
						CreatedAt = DateTime.ParseExact(x.Element("created_at").Value, "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture).ToLocalTime(),
						UserName = x.Element("user").Element("name").Value,
						ScreenName = x.Element("user").Element("screen_name").Value,
						Text = x.Element("text").Value,
                        inReplyToID = x.Element( "in_reply_to_status_id").Value
					})
					.ToArray();
			}
		}

		#region RequestBuilder

		public class RequestBuilder
		{
			private const string VERSION = "1.0";
			private const string SIGNATURE_METHOD = "HMAC-SHA1";

			private readonly OAuthInfo oauth;
			private readonly string method;
			private readonly IDictionary<string, string> customParameters;
			private readonly string url;

			public RequestBuilder(OAuthInfo oauth, string method, string url)
			{
				this.oauth = oauth;
				this.method = method;
				this.url = url;
				customParameters = new Dictionary<string, string>();
			}

			public RequestBuilder AddParameter(string name, string value)
			{
				customParameters.Add(name, value.EncodeRFC3986());
				return this;
			}

			public WebResponse Execute()
			{
				var timespan = GetTimestamp();
				var nonce = CreateNonce();

				var parameters = new Dictionary<string, string>(customParameters);
				AddOAuthParameters(parameters, timespan, nonce);

				var signature = GenerateSignature(parameters);
				var headerValue = GenerateAuthorizationHeaderValue(parameters, signature);

				var request = (HttpWebRequest)WebRequest.Create(GetRequestUrl());
				request.Method = method;
				request.ContentType = "application/x-www-form-urlencoded";

				request.Headers.Add("Authorization", headerValue);

				WriteRequestBody(request);

				return request.GetResponse();
			}


			private void WriteRequestBody(HttpWebRequest request)
			{
				if (method == "GET")
					return;

				var requestBody = Encoding.ASCII.GetBytes(GetCustomParametersString());
				using (var stream = request.GetRequestStream())
					stream.Write(requestBody, 0, requestBody.Length);
			}

			private string GetRequestUrl()
			{
				if (method != "GET" || customParameters.Count == 0)
					return url;

				return string.Format("{0}?{1}", url, GetCustomParametersString());
			}

			private string GetCustomParametersString()
			{
				return customParameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)).Join("&");
			}

			private string GenerateAuthorizationHeaderValue(IEnumerable<KeyValuePair<string, string>> parameters, string signature)
			{
				return new StringBuilder("OAuth ")
					.Append(parameters.Concat(new KeyValuePair<string, string>("oauth_signature", signature))
								.Where(x => x.Key.StartsWith("oauth_"))
								.Select(x => string.Format("{0}=\"{1}\"", x.Key, x.Value.EncodeRFC3986()))
								.Join(","))
					.ToString();
			}

			private string GenerateSignature(IEnumerable<KeyValuePair<string, string>> parameters)
			{
				var dataToSign = new StringBuilder()
					.Append(method).Append("&")
					.Append(url.EncodeRFC3986()).Append("&")
					.Append(parameters
								.OrderBy(x => x.Key)
								.Select(x => string.Format("{0}={1}", x.Key, x.Value))
								.Join("&")
								.EncodeRFC3986());

				var signatureKey = string.Format("{0}&{1}", oauth.ConsumerSecret.EncodeRFC3986(), oauth.AccessSecret.EncodeRFC3986());
				var sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(signatureKey));

				var signatureBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(dataToSign.ToString()));
				return Convert.ToBase64String(signatureBytes);
			}

			private void AddOAuthParameters(IDictionary<string, string> parameters, string timestamp, string nonce)
			{
				parameters.Add("oauth_version", VERSION);
				parameters.Add("oauth_consumer_key", oauth.ConsumerKey);
				parameters.Add("oauth_nonce", nonce);
				parameters.Add("oauth_signature_method", SIGNATURE_METHOD);
				parameters.Add("oauth_timestamp", timestamp);
				parameters.Add("oauth_token", oauth.AccessToken);
			}

			private static string GetTimestamp()
			{
				return ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
			}

			private static string CreateNonce()
			{
				return new Random().Next(0x0000000, 0x7fffffff).ToString("X8");
			}
		}

		#endregion
	}

	public static class TinyTwitterHelperExtensions
	{
		public static string Join<T>(this IEnumerable<T> items, string separator)
		{
			return string.Join(separator, items.ToArray());
		}

		public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T value)
		{
			return items.Concat(new[] { value });
		}

		public static string EncodeRFC3986(this string value)
		{
			// From Twitterizer http://www.twitterizer.net/

			if (string.IsNullOrEmpty(value))
				return string.Empty;

			var encoded = Uri.EscapeDataString(value);

			return Regex
				.Replace(encoded, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper())
				.Replace("(", "%28")
				.Replace(")", "%29")
				.Replace("$", "%24")
				.Replace("!", "%21")
				.Replace("*", "%2A")
				.Replace("'", "%27")
				.Replace("%7E", "~");
		}
	}
}
