using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqDebugDataReset : WebAPI
	{
		public ReqDebugDataReset()
		{
			this.name = "debug/reset";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
