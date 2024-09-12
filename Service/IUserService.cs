namespace Store.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}