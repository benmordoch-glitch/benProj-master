using benProj.Models;

namespace benProj.Views;

public partial class CreatingPath : ContentPage
{
    public enum TrainingStatus
    {
        Stop,
        Run,
        Pause
    }

    private TrainingStatus trainingStatus = TrainingStatus.Stop;
    private IDispatcherTimer timer;

    private List<Microsoft.Maui.Devices.Sensors.Location> gpsLocations = new();
    private Microsoft.Maui.Devices.Sensors.Location? referenceLocation;

    private const double MinDistanceMeters = 8;
    private const double EarthRadius = 6378137; // meters

    // -------------------- DISTANCE FILTER --------------------

    private bool IsFarEnough(Microsoft.Maui.Devices.Sensors.Location newLocation)
    {
        if (gpsLocations.Count == 0) return true;

        var last = gpsLocations.Last();

        // 1. חישוב מרחק במטרים
        var distance = Microsoft.Maui.Devices.Sensors.Location.CalculateDistance(last, newLocation, DistanceUnits.Kilometers) * 1000;

        // 2. בדיקת מהירות (במטרים לשנייה)
        // אם המהירות נמוכה מ-0.5 מטר לשנייה (בערך 1.8 קמ"ש), אנחנו מניחים שאתה עומד
        double speed = newLocation.Speed ?? 0;

        // תנאי: הוסף נקודה רק אם עברת מרחק משמעותי והמהירות היא של הליכה/ריצה
        return distance >= 8 && speed > 0.5;
    }

    // -------------------- SMOOTHING --------------------

    private const double Alpha = 0.2; // בין 0 ל-1

    private Microsoft.Maui.Devices.Sensors.Location SmoothLocation(Microsoft.Maui.Devices.Sensors.Location newLoc)
    {
        if (gpsLocations.Count == 0) return newLoc;

        var last = gpsLocations.Last();
        double smoothLat = last.Latitude + Alpha * (newLoc.Latitude - last.Latitude);
        double smoothLon = last.Longitude + Alpha * (newLoc.Longitude - last.Longitude);

        return new Microsoft.Maui.Devices.Sensors.Location(smoothLat, smoothLon);
    }
    // -------------------- CONVERT TO METERS --------------------

    private (double x, double y) ConvertToMeters(Location loc)
    {
        var refLat = referenceLocation!.Latitude;
        var refLon = referenceLocation.Longitude;

        double dLat = (loc.Latitude - refLat) * Math.PI / 180;
        double dLon = (loc.Longitude - refLon) * Math.PI / 180;

        double x = dLon * EarthRadius * Math.Cos(refLat * Math.PI / 180);
        double y = dLat * EarthRadius;

        return (x, y);
    }

    // -------------------- CONSTRUCTOR --------------------

    public CreatingPath()
    {
        InitializeComponent();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);

        timer.Tick += async (s, e) =>
        {
            if (trainingStatus != TrainingStatus.Run) return;

            var location = await GetLocation();

            // אם הנקודה סוננה בגלל דיוק נמוך (HorizontalAccuracy), היא תחזור כ-null
            if (location == null) return;

            // בדיקה אם המשתמש באמת זז מספיק
            if (IsFarEnough(location))
            {
                // החלקת הנקודה (מסיר קוצים קטנים)
                var smooth = SmoothLocation(location);

                if (referenceLocation == null)
                    referenceLocation = smooth;

                gpsLocations.Add(smooth);

                // עדכון התצוגה
                lblGeo.Text = $"Lat: {smooth.Latitude:F6}, Lon: {smooth.Longitude:F6}";

                graphicView.Drawable = new DrawPath
                {
                    Locations = gpsLocations,
                    ReferenceLocation = referenceLocation,
                    ConvertToMetersFunc = ConvertToMeters
                };

                graphicView.Invalidate();
            }
        };
    }

    // -------------------- START / PAUSE --------------------

    private async void Button_Run(object sender, EventArgs e)
    {
        if (trainingStatus == TrainingStatus.Stop)
        {
            gpsLocations.Clear();
            referenceLocation = null;
        }

        if (trainingStatus == TrainingStatus.Stop || trainingStatus == TrainingStatus.Pause)
        {
            trainingStatus = TrainingStatus.Run;

            butStop.IsEnabled = true;
            butStartPause.Text = "Pause";
            butStartPause.BackgroundColor = Colors.DarkGreen;

            timer.Start();
        }
        else
        {
            trainingStatus = TrainingStatus.Pause;
            timer.Stop();

            butStartPause.Text = "Continue";
            butStartPause.BackgroundColor = Colors.LightGreen;
        }
    }

    // -------------------- STOP --------------------

    private void Button_Stop(object sender, EventArgs e)
    {
        timer.Stop();

        gpsLocations.Clear();
        referenceLocation = null;

        trainingStatus = TrainingStatus.Stop;

        butStop.IsEnabled = false;
        butStartPause.Text = "Start";
        butStartPause.BackgroundColor = Colors.Green;

        lblGeo.Text = "";
        graphicView.Drawable = null;
        graphicView.Invalidate();
    }

    // -------------------- GET LOCATION --------------------

    private async Task<Microsoft.Maui.Devices.Sensors.Location?> GetLocation()
    {
        try
        {
            // הגדרה של "דיוק גבוה" (Best) - זה משתנה ש-MAUI מזהה בכל מצב
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));

            var location = await Geolocation.GetLocationAsync(request);

            // אם המכשיר לא הצליח להביא מיקום בכלל
            if (location == null) return null;

            return location;
        }
        catch { return null; }
    }
}