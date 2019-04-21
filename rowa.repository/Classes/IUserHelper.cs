namespace rowa.repository.Classes
{
    public interface IUserHelper
    {
        string EncryptPassword(string password);

        void LogIn(string email);
    }
}
