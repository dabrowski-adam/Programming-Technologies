using System;

namespace Data
{
    public class ISBN : IEquatable<ISBN>
    {
        public String Id { get; set; }

        public bool Equals(ISBN other)
        {
            return other.Id == Id;
        }
    }
}