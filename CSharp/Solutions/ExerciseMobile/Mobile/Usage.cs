using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
	class Usage
	{
		private double batteryPercentage;
		private List<Call> history;

		public List<Call> History
		{
			get
			{
				return history;
			}
		}

		public Usage( )
		{
			batteryPercentage = 100;
			history = new List<Call>();
		}

		public void NewCall(CallType type)
		{
			history.Add(new Call(type));
		}

		public void EndCall()
		{
			history[history.Count - 1].End();
		}

		public override string ToString()
		{
			string result = "";
			result += "Battery: " + batteryPercentage + "%\n";
			result += "Call History:\n";
			foreach (Call call in history) {
				result += String.Format("Start: {0} | Duration {1} seconds\n", call.StartTime.ToString("MM/dd/yyyy HH:mm:ss"), call.Duration); 
			}
			return result;
		}
	}
}
