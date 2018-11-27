namespace Data
{
    public interface IDescription
    {
        string Title { get; }
        string Author { get; }
        float Price { get; set; }
    }
}
