namespace MyPhotoshop
{
    public class RotationParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент", MaxValue = 10, MinValue = 0, Increment = 0.1, DefaultValue = 1)]
        public double Angle { get; private set; }
    }
}