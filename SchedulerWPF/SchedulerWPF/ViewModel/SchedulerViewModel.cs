using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        public event PropertyChangedEventHandler PropertyChanged;
        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointments();
        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        private void AddAppointments()
        {
            var meeting = new Meeting()
            {
                From = new DateTime(2020, 07, 05, 10, 0, 0),
                To = new DateTime(2020, 07, 05, 11, 0, 0),
                EventName = "Occurs Daily",
                BackgroundColor = new SolidColorBrush(Colors.LightSeaGreen),
                ForegroundColor = new SolidColorBrush(Colors.White),
                Id = 1
            };
            var exceptionDate = new DateTime(2020, 07, 09);
            meeting.RecurrenceRule = "FREQ=DAILY;COUNT=20";
            meeting.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
              exceptionDate
            };
            this.Meetings.Add(meeting);
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    

