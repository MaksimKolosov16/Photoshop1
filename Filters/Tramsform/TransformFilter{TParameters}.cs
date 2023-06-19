using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        private ITransformer<TParameters> _transformer;

        public TransformFilter(
            string name,
            ITransformer<TParameters> transformer) : base(name)
        {
            _transformer = transformer;
        }

        public override Photo Process(Photo original, TParameters values)
        {
            var oldSize = new Size(original.Width, original.Height);
            _transformer.Prepare(oldSize, values);
            var newSize = _transformer.ResultSize;

            var result = new Photo(newSize.Width, newSize.Height);

            for (var x = 0; x < newSize.Width; x++)
            for (var y = 0; y < newSize.Height; y++)
            {
                var point = new Point(x, y);
                var oldPoint = _transformer.MapPoint(point);
                if (oldPoint.HasValue)
                    result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
            }

            return result;
        }
    }
}