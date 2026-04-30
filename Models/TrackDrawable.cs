using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.Models
{
    public class TrackDrawable : IDrawable
    {
        public ObservableCollection<PointF> Points { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (Points == null || Points.Count < 2)
                return;

            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 3;

            for (int i = 0; i < Points.Count - 1; i++)
            {
                canvas.DrawLine(Points[i], Points[i + 1]);
            }

            canvas.FillColor = Colors.Red;
            foreach (var p in Points)
            {
                canvas.FillCircle(p, 5);
            }
        }
    }
}
