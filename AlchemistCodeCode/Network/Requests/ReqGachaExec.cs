using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGachaExec : WebAPI
	{
		public ReqGachaExec(string gachaid)
		{
			this.name = "gacha/exec";
			this.body = WebAPI.GetRequestString("\"gachaid\":\"" + gachaid + "\"");
		}

		public ReqGachaExec(string iname, int free = 0, int num = 0)
		{
			this.name = "gacha/exec";
			this.body = "\"gachaid\":\"" + iname + "\",";
			this.body = this.body + "\"free\":" + free.ToString();
			if (num > 0)
			{
				this.body = this.body + ",\"ticketnum\":" + num.ToString();
			}
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
