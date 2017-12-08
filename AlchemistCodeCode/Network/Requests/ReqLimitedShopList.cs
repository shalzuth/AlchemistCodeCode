using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqLimitedShopList : WebAPI
	{
		public ReqLimitedShopList()
		{
			this.name = "shop/limited/shoplist";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
