1.0 Application Overview

A chess game played via twitter.  This application will use twitter tweets to communicate between game players using the account @ChessByBird.  The tweet will contain the chess player move information using standard chess notation. The ChessByBird service will get the tweets using a Twitter API Restful Web service.  The application will post a metadata container along with the gameboard image which will provide game state details.  The chess board game pieces and their location will be mapped onto a grid. Using the algebraic notation for chess the application will verify the move is valid.  The player's valid move will be tweeted and the image will be rendered and posted. Invalid moves will not update gameboard image state and an error message will be sent to the sender, via the @ChessByBird account.

1.1 Objectives
Develop a running service that can make API Web service calls into twitter (to handle tweets) and flickr (to handle images). The service needs to have the ability to parse chess commands, check command syntax, handle improper commands, and process chess moves handling both valid and invalid moves. The service will also dynamically generate a new gameboard image.

    Call the twitter API Web service: Get @ChessByBird tweets
    Parse tweet chess moves: determine players and move
    Get the current game board image URL and game state
    Determine the game pieces location using using metadata container
    Processes player's chess command for a valid move
    Generate updated game board image dynamically
    Post the updated game board image to a picture file saving site
    Call the twitter API Web service : post chess move tweets @ChessByBird


2.0 Nonfunctional Requirements

    The application shall check chessbybird twitter feed every 20 seconds.
    The application shall validate all chess moves with 100% accuracy.
    The application shall remain operational as long as active games are being played.
    The application shall notify the current player if invalid move was played with in 30 seconds.
    The application shall notify the opponent of its turn within 30 seconds of the current player moved.
    The application shall display the current state of the game to the opponent  every time a new move is made.

3.0 Functional Requirements

    The application shall adhere to the rules of chess.
    The application shall be able to interpret Forsyth-Edwards Notation (FEN) which is a method for describing a particular board position of a chess game. 
    The chess pieces shall accurately reflect their rank through image and movement. Algebraic notation (or AN) is a method for recording and describing the moves in a game of chess. 
    The application shall have a communication layer for image storage and user interface.