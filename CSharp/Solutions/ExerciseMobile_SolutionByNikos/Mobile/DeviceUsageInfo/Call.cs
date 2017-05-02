using System;
using System.Threading;
using Mobile.DeviceInfo;

namespace Mobile.DeviceUsageInfo
{
    class Call
    {
        public long Caller { get; private set; }
        public long Callee { get; private set; }
        public DateTime CallStartTime { get; private set; }
        public DateTime CallEndTime { get; private set; }
        public int DurationInSeconds { get; private set; }

        public Call(long caller, long callee)
        {
            Caller = caller;
            Callee = callee;
        }

        public void StartCall(bool autostop = false)
        {
            CallStartTime = DateTime.Now;
            int Duration = new Random(DateTime.Now.Millisecond).Next(5, 60);

            if (autostop)
            {
                Console.WriteLine("Calling {0} from {1}...", Callee, Caller);
                Thread T = new Thread(delegate ()
                {
                    Thread.Sleep(Duration * 1000);
                    lock (this)
                        StopCall();
                });
                T.IsBackground = true;
                T.Start();

                while (T.IsAlive) { }

                Console.WriteLine("Call from {0} to {1} has ended. Duration: {2} seconds.", Caller, Callee, DurationInSeconds);
            }              
        }

        public void StopCall()
        {
            if (CallStartTime.GetHashCode() == 0)
                throw new Exception("Call has not been started yet and therefore it cannot be stopped.");

            if (CallEndTime.GetHashCode() != 0)
                throw new Exception("Call has already been stopped.");


            CallEndTime = DateTime.Now;
            DurationInSeconds = (int)(CallEndTime - CallStartTime).TotalSeconds;
        }

        public bool IsOutboundCall(MobileDevice device)
        {
            return device.PhoneNumber == Caller;
        }
    }
}
