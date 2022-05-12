using System;

namespace quantum_lines
{
    public class Possibility
    {
        private double _value;

        public Possibility(double value)
        {
            if (value > 1f || value < 0f) throw new ArgumentOutOfRangeException();
            _value = value;
        }

        public override string ToString()
        {
            return $"{Math.Round(_value, 2) * 100f}%";
        }
    }
}