using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Maui.Graphics;

namespace benProj.Models
{
    class DrawPath : IDrawable
    {
        public List<Location> Locations { get; set; } = new List<Location>();
        public Location? ReferenceLocation { get; set; }
        public Func<Location, (double x, double y)> ConvertToMetersFunc { get; set; }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (Locations == null || Locations.Count < 2)
                return;

            canvas.StrokeColor = Colors.CadetBlue;
            canvas.StrokeSize = 3;

            // 1. Find bounds
            double minLat = Locations.Min(l => l.Latitude);
            double maxLat = Locations.Max(l => l.Latitude);
            double minLon = Locations.Min(l => l.Longitude);
            double maxLon = Locations.Max(l => l.Longitude);

            double latRange = maxLat - minLat;
            double lonRange = maxLon - minLon;

            // Avoid division by zero
            if (latRange == 0) latRange = 0.00001;
            if (lonRange == 0) lonRange = 0.00001;

            // 2. Convert each GPS point to canvas coordinates
            List<PointF> screenPoints = new();

            foreach (var loc in Locations)
            {
                float x = (float)((loc.Longitude - minLon) / lonRange * dirtyRect.Width);
                float y = (float)((maxLat - loc.Latitude) / latRange * dirtyRect.Height);

                screenPoints.Add(new PointF(x, y));
            }

            // 3. Draw polyline
            //for (int i = 0; i < screenPoints.Count - 1; i++)
            //{
            //  var p1 = screenPoints[i];
            //  var p2 = screenPoints[i + 1];

            //  canvas.DrawLine(p1.X, p1.Y, p2.X, p2.Y);
            //}
            var path = new PathF();

            for (int i = 0; i < screenPoints.Count - 1; i++)
            {
                var p1 = screenPoints[i];
                var p2 = screenPoints[i + 1];

                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                path.QuadTo(p1.X, p1.Y, midX, midY);
            }

            canvas.DrawPath(path);
        }
    }
}
