using System;

namespace Data
{
    public class Actor
    {
        public String Name { get; private set; }

        public Actor(String name)
        {
            this.Name = name;  
        }
    }
}
