using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMailRead : WebAPI
	{
		public ReqMailRead(long[] mailids, bool period, int page)
		{
			this.name = "mail/read";
			this.body = "\"mailids\":[";
			for (int i = 0; i < mailids.Length; i++)
			{
				this.body += mailids[i].ToString();
				if (i != mailids.Length - 1)
				{
					this.body += ",";
				}
			}
			this.body += "],";
			this.body += "\"page\":";
			this.body += page;
			this.body += ",";
			this.body += "\"period\":";
			this.body += ((!period) ? 0 : 1);
			this.body = WebAPI.GetRequestString(this.body);
		}

		public ReqMailRead(long[] mailids, int[] periods, int page)
		{
			this.name = "mail/read";
			this.body = "\"mailids\":[";
			for (int i = 0; i < mailids.Length; i++)
			{
				this.body += mailids[i].ToString();
				if (i != mailids.Length - 1)
				{
					this.body += ",";
				}
			}
			this.body += "],";
			this.body += "\"page\":";
			this.body += page;
			this.body += ",";
			this.body += "\"period\":";
			this.body += periods[0];
			this.body = WebAPI.GetRequestString(this.body);
		}

		public ReqMailRead(long mailid, bool period, int page, string iname)
		{
			this.name = "mail/read";
			this.body = "\"mailids\":[";
			this.body += mailid.ToString();
			this.body += "],";
			this.body += "\"page\":";
			this.body += page;
			this.body += ",";
			this.body += "\"period\":";
			this.body += ((!period) ? 0 : 1);
			this.body += ",";
			this.body += "\"selected\":\"";
			this.body += iname;
			this.body += "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
