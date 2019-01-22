namespace Data
{
    public interface IInvoice
    {
        IBook Book { get; }
        float Price { get; }
        int Number { get; }
    }
}
