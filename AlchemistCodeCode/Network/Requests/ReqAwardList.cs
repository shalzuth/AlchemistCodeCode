using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqAwardList : WebAPI
	{
		public ReqAwardList()
		{
			this.name = "award";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
