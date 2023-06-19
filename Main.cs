using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var window = new MainWindow();

            window.AddFilter(new PixelFilter<LightningParameters>(
                "Осветление/затемнение",
                (original, parameters) => parameters.Coefficient * original));

            window.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (original, parameters) =>
                {
                    var l = original.R * 0.2126 + original.G * 0.7152 + original.B * 0.0722;
                    return new Pixel(l, l, l);
                }));

            window.AddFilter(new PixelFilter<EmptyParameters>(
                "Сепия",
                (original, parameters) =>
                {
                    var r = Pixel.Trim(original.R * 0.393 + original.G * 0.769 + original.B * 0.189);
                    var g = Pixel.Trim(original.R * 0.349 + original.G * 0.686 + original.B * 0.168);
                    var b = Pixel.Trim(original.R * 0.272 + original.G * 0.534 + original.B * 0.131);
                    return new Pixel(r, g, b);
                }));

            window.AddFilter(
                new TransformFilter(
                    "Отразить по горизонтали",
                    (size) => size,
                    (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            window.AddFilter(new TransformFilter(
                "Повернуть против ч.с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
            ));

            window.AddFilter(new TransformFilter<RotationParameters>(
                "Свободное вращение",
                new RotateTransformer()));

            window.AddFilter(
                new TransformFilter<EmptyParameters>(
                    "Отразить по горизонтали",
                    new HorizontalReflectionTransformer()));

            Application.Run(window);
        }
    }
}