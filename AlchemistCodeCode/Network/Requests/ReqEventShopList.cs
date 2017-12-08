using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqEventShopList : WebAPI
	{
		public ReqEventShopList()
		{
			this.name = "shop/event/shoplist";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
