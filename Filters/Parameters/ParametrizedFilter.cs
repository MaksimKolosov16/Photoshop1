namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters : IParameters, new()
    {
        private readonly string _name;
        private IParametersHandler<TParameters> _handler = new SimpleParametersHandler<TParameters>();

        protected ParametrizedFilter(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        public ParameterInfo[] GetParameters()
        {
            return _handler.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = _handler.CreateParameters(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters values);
    }
}