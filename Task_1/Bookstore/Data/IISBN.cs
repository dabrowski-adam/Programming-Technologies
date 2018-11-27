using System;
namespace Data
{
    public interface IISBN : IEquatable<IISBN>
    {
        string Id { get; set; }

        bool Equals(Object obj);

        int GetHashCode();
    }
}
