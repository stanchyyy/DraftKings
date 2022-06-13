namespace Book_lib.Models
{
    public interface IUserModel
    {
        string EmailAddress { get; set; }
        string Password { get; }
        string UserName { get; set; }

        string ToString();
    }
}