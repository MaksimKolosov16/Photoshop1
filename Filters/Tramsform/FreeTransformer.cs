using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        private Func<Size, Size> sizeTransformer;
        private Func<Point, Size, Point?> pointTransformer;

        public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point?> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public Size ResultSize { get; private set; }
        public Size OldSize { get; private set; }
        
        public void Prepare(Size size, EmptyParameters parameters)
        {
            OldSize = size;
            ResultSize = sizeTransformer(size);
        }


        public Point? MapPoint(Point point)
        {
            return pointTransformer(point, OldSize);
        }
    }
}