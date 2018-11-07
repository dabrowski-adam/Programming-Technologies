using System;

namespace Data
{
    public class ISBN : IEquatable<ISBN>
    {
        public String Id { get; set; }

        public ISBN(string id) {
            this.Id = id;
        }

        public bool Equals(ISBN other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(Object obj)
        {
            ISBN other = obj as ISBN;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}