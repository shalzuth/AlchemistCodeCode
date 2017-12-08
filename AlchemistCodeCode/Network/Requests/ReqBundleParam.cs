using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBundleParam : WebAPI
	{
		public ReqBundleParam()
		{
			this.name = "bundle";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
