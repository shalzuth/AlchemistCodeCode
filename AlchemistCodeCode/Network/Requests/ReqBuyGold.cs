using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBuyGold : WebAPI
	{
		public ReqBuyGold(int coin)
		{
			this.name = "shop/gold/buy";
			this.body = WebAPI.GetRequestString("\"coin\":" + coin.ToString());
		}
	}
}
