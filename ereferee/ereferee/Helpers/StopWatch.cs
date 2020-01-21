using System.Threading;

namespace ereferee.Helpers
{
    public static class StopWatch
    {
        public static int Minutes { get; set; } = 0;
        public static int Seconds { get; set; } = 0;
        private static Timer _timer = new Timer(new TimerCallback(Tick));

        private static void Tick(object state)
        {
            if (Seconds == 59)
            {
                Seconds = 0;
                Minutes++;
            }
            else
                Seconds++;
        }

        public static void Start()
        {
            _timer.Change(0, 1000);
        }

        public static void Stop()
        {
            _timer.Change(Timeout.Infinite, 1000);
        }

        public static void Restart()
        {
            Reset();
            Start();
        }

        public static void Reset()
        {
            Minutes = 0;
            Seconds = 0;
        }

        public static string ShowTime()
        {
            var time = Minutes.ToString("D2") + ":" + Seconds.ToString("D2");
            return (time);
        }
    }
}
