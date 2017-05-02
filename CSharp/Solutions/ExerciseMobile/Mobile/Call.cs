using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
	enum CallType
	{
		Incoming,
		Outgoing
	}

	class Call
	{
		private DateTime startTime;
		private DateTime endTime;
		private CallType type;

		public DateTime StartTime {
			get
			{
				return startTime;
			}
		}

		public DateTime EndTime
		{
			get
			{
				return endTime;
			}
		}

		public double Duration
		{
			get
			{
				TimeSpan span = endTime - startTime;
				return span.Seconds;
			}
		}

		public CallType Type
		{
			get
			{
				return type;
			}
		}

		public Call(CallType type)
		{
			this.startTime = DateTime.Now;
			this.type = type;
		}

		public void End()
		{
			this.endTime = DateTime.UtcNow;
		}
	}
}
