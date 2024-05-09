namespace API.Hcon
{
    public interface IConHubClient
    {
        Task SendOffersToUser(string message);
    }
}
