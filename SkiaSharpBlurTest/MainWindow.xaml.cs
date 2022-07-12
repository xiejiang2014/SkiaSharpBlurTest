using System;
using System.Windows.Forms.Integration;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace SkiaSharpBlurTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnPaintCanvas(object? sender, SKPaintSurfaceEventArgs e)
        {
            OnPaintSurface
                (
                 e.Surface.Canvas,
                 e.Info.Width,
                 e.Info.Height
                );
        }


        private void OnGLControlHost(object? sender, EventArgs e)
        {
            var glControl = new SKGLControl();
            glControl.PaintSurface += OnPaintGL;
            glControl.Dock         =  System.Windows.Forms.DockStyle.Fill;

            var host = (WindowsFormsHost)sender;
            host.Child = glControl;
        }


        private void OnPaintGL(object? sender, SKPaintGLSurfaceEventArgs e)
        {
            OnPaintSurface
                (
                 e.Surface.Canvas,
                 e.BackendRenderTarget.Width,
                 e.BackendRenderTarget.Height
                );
        }

        private void OnPaintSurface
        (
            SKCanvas canvas,
            int      width,
            int      height
        )
        {
            canvas.Clear(SKColors.Gray);

            using var paint = new SKPaint();
            paint.ImageFilter = SKImageFilter.CreateBlur(500, 500);
            paint.Color       = SKColors.BlueViolet;
            

            canvas.DrawRect( new SKRect(100, 100, 200, 200), paint);

        }


    }
}