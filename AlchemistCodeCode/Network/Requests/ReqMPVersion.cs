using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMPVersion : WebAPI
	{
		public ReqMPVersion()
		{
			this.name = "btl/multi/check";
			this.body = string.Empty;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
