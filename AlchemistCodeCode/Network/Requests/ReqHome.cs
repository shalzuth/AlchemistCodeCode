using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqHome : WebAPI
	{
		public ReqHome()
		{
			this.name = "home";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
