using System;

namespace Data
{
    public interface IBook : IEquatable<IBook>
    {
        IISBN ISBN { get; }

        bool Equals(Object obj);

        int GetHashCode();
    }
}
