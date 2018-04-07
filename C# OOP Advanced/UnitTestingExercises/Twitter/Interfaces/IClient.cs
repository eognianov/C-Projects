public interface IClient
{
    void WriteTweet(string message);

    void SendTweetToServer(string message);
}