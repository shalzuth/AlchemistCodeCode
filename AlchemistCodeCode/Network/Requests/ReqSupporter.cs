using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSupporter : WebAPI
	{
		public ReqSupporter()
		{
			this.name = "btl/com/supportlist";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
