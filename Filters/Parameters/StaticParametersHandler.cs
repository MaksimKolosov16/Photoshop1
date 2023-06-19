using System.Linq;
using System.Reflection;

namespace MyPhotoshop
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        private static PropertyInfo[] _properties;
        private static ParameterInfo[] _descriptions;

        static StaticParametersHandler()
        {
            _properties = typeof(TParameters)
                .GetProperties()
                .Where(x => x.GetCustomAttribute<ParameterInfo>() != null)
                .ToArray();
            
            _descriptions = typeof(TParameters)
                .GetProperties()
                .Where(x => x.GetCustomAttribute<ParameterInfo>() != null)
                .Select(x => x.GetCustomAttribute<ParameterInfo>())
                .ToArray();
        }

        public ParameterInfo[] GetDescription()
        {
            return _descriptions;
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            
            for (var i = 0; i < _properties.Length; i++)
                _properties[i].SetValue(parameters, values[i]);

            return parameters;
        }
    }
}