using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemAbilPointPaid : WebAPI
	{
		public ReqItemAbilPointPaid()
		{
			this.name = "item/addappaid";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
