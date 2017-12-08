using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGacha : WebAPI
	{
		public ReqGacha()
		{
			this.name = "gacha";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
