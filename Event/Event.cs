using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public static class Event1
    {
        public class TimeInfo : EventArgs
        {
            public int hour, minute, second;

            public TimeInfo(int hour, int minute, int second)
            {
                this.hour = hour;
                this.minute = minute;
                this.second = second;
            }
        }

        public class Observable
        {
            private int second;

            public delegate void observers(object observable, TimeInfo timeInfo);
            public event observers observer;

            public void Run()
            {
                for (;;)
                {
                    System.Threading.Thread.Sleep(100);
                    var now = DateTime.Now;
                    if (now.Second != second)
                    {
                        var timeInfo = new TimeInfo(now.Hour, now.Minute, now.Second);
                        if (observer != null)
                            observer(this, timeInfo);
                    }
                    second = now.Second;
                }
            }
        }

        public class Observer
        {
            public void Subscribe(Observable observable)
            {
                observable.observer += TimeHasChanged;
            }

            public void TimeHasChanged(object observable, TimeInfo timeInfo)
            {
                Console.WriteLine("Current time: {0}:{1}:{2}", timeInfo.hour, timeInfo.minute, timeInfo.second);
            }
        }
    }

    public static class Event2
    {
        public delegate void EventHandler();
        public static event EventHandler _show;

        static void Run()
        {
	        _show += Dog;
	        _show += Cat;
	        _show += Mouse;
	        _show += Mouse;

            if (_show != null) _show.Invoke();
        }

        static void Cat()
        {
            Console.WriteLine("Cat");
        }

        static void Dog()
        {
            Console.WriteLine("Dog");
        }

        static void Mouse()
        {
            Console.WriteLine("Mouse");
        }
    }
}
