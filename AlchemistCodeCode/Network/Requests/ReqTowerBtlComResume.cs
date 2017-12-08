using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerBtlComResume : WebAPI
	{
		public ReqTowerBtlComResume(long btlid)
		{
			this.name = "tower/btl/resume";
			this.body = "\"btlid\":" + btlid;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
