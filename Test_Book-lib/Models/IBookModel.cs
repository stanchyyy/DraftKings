namespace Book_lib.Models
{
    public interface IBookModel
    {
        AuthorModel Author { get; set; }
        int Id { get; set; }
        string Publisher { get; set; }
        DateTime ReleaseDate { get; set; }
        string Title { get; set; }
    }
}