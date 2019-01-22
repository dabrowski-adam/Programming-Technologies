using System.Collections.Generic;

namespace Data
{
    public interface ICatalog : IDictionary<IBook, IDescription>
    {
    }
}
