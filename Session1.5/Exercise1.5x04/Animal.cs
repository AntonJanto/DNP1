using System;

namespace Zoo
{
    class Animal : IComparable
    {
        public string Type { get; set; }
        public double Weight { get; set; }
        public int Speed { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Animal otherAnimal = obj as Animal;
            if (otherAnimal != null)
                return this.Weight.CompareTo(otherAnimal.Weight);
            else
                throw new ArgumentException("Object is not Animal");
        }

        public override string ToString()
        {
            return $"Animal: {Type}\n" +
                $"Weight: {Weight}\n" +
                $"Speed: {Speed}";               
        }
    }
}
