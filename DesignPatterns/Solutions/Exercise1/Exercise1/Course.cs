using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class Course : IObservable<Course>
    {
        public string Name { get; set; }
        private DateTime startTime;
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                foreach(IObserver<Course> observer in _courseObservers)
                {
                    observer.OnNext(this);
                }
            }
        }
        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
                foreach (IObserver<Course> observer in _courseObservers)
                {
                    observer.OnNext(this);
                }
            }
        }

        private List<IObserver<Course>> _courseObservers;

        public Course(string name, DateTime startTime, DateTime endTime)
        {
            _courseObservers = new List<IObserver<Course>>();
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public IDisposable Subscribe(IObserver<Course> observer)
        {
            if (!_courseObservers.Contains(observer))
            {
                _courseObservers.Add(observer);
            }

            return new Disposer(_courseObservers, observer);
        }

        public void Unsubsribe(IObserver<Course> observer)
        {
            if (_courseObservers.Contains(observer))
            {
                _courseObservers.Remove(observer);
            }
        }

        private class Disposer : IDisposable
        {
            // The observers list recieved from the observable
            private List<IObserver<Course>> _observers;
            // The observer instance to unsubscribe
            private IObserver<Course> _observer;

            public Disposer(List<IObserver<Course>> observers, IObserver<Course> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

    }
}
