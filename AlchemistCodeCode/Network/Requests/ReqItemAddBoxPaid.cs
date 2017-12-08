using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemAddBoxPaid : WebAPI
	{
		public ReqItemAddBoxPaid(long iid)
		{
			this.name = "item/addboxpaid";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
