using System.Linq;
using System.Reflection;

namespace MyPhotoshop
{
    public class SimpleParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        public ParameterInfo[] GetDescription()
        {
            return typeof(TParameters)
                .GetProperties()
                .Where(x => x.GetCustomAttribute<ParameterInfo>() != null)
                .Select(x => x.GetCustomAttribute<ParameterInfo>())
                .ToArray();
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();

            var properties = parameters.GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttribute<ParameterInfo>() != null)
                .ToArray();

            for (var i = 0; i < properties.Length; i++)
                properties[i].SetValue(parameters, values[i]);

            return parameters;
        }
    }
}