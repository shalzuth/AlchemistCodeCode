using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqProductParam : WebAPI
	{
		public ReqProductParam()
		{
			this.name = "product";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
