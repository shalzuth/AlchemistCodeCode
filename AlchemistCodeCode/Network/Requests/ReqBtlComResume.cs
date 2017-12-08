using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComResume : WebAPI
	{
		public ReqBtlComResume(long btlid)
		{
			this.name = "btl/com/resume";
			this.body = "\"btlid\":" + btlid;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
