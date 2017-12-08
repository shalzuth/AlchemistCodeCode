using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqHikkoshiToken : WebAPI
	{
		public ReqHikkoshiToken()
		{
			this.name = "hikkoshi/token";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
