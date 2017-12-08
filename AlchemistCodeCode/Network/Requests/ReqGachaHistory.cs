using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGachaHistory : WebAPI
	{
		public ReqGachaHistory()
		{
			this.name = "gacha/history";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
