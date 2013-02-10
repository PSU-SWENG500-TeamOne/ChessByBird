using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ChessByBird.TwitterProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var oauth = GetOAuthInfo();
            var twitter = new TinyTwitter(oauth);
            var startingtime = DateTime.Now;
            

            //while (true)
            //{
            var myMentions = twitter.GetMentions(300328033800306680, 20);
                myMentions.ToList().ForEach(
                    x =>
                    {
                        string moveString = "not found";
                        
                        if (x.Text.Contains("*"))
                        {
                            int startIndex = x.Text.IndexOf("*");
                            int endIndex = x.Text.LastIndexOf("*");
                            moveString = x.Text.Substring(startIndex, endIndex-startIndex+1);
                        }

                        Console.WriteLine("Now gathering info about tweet #" + x.Id.ToString() +".");
                        Console.WriteLine("  --  The sender of this tweet was '" + x.ScreenName + " and it was in reply to " + x.inReplyToID + "'.");
                        Console.WriteLine("  --  The text of this tweet was: '" + x.Text + "'.");
                        Console.WriteLine("  --  The move attached to this tweet was " + moveString + ".");
                        
                    }
                );
            Console.WriteLine("This concludes the current mentions");

            //var tweet = twitter.GetSpecificTweet(299722128025063425);


            var status = Guid.NewGuid().ToString();
            twitter.UpdateStatus(status);

           // }

        }

        
        
        private static OAuthInfo GetOAuthInfo()
        {
            System.Reflection.Assembly _assembly = Assembly.GetExecutingAssembly();
            System.IO.Stream _xmlStream = _assembly.GetManifestResourceStream("ChessByBird.TwitterProject.oauth-info.xml");

            var serializer = new XmlSerializer(typeof(OAuthInfo));
            return (OAuthInfo)serializer.Deserialize(_xmlStream);

        }
    }
}
