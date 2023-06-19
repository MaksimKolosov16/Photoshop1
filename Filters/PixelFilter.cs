using System;
using System.Windows.Forms;

namespace MyPhotoshop
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        private readonly Func<Pixel, TParameters, Pixel> _processor;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processor) : base(name)
        {
            _processor = processor;
        }

        public override Photo Process(Photo original, TParameters values)
        {
            var result = new Photo(original.Width, original.Height);

            for (var x = 0; x < result.Width; x++)
            for (var y = 0; y < result.Height; y++)
            {
                result[x, y] = _processor(original[x, y], values);
            }

            return result;
        }
    }
}