using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.ViewModels
{
    public class TrackViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PointF> Points { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public TrackViewModel()
        {
            Points.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Points));
            };
        }

        public void AddPoint(float x, float y)
        {
            Points.Add(new PointF(x, y));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
