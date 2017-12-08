using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqProductBuy : WebAPI
	{
		public ReqProductBuy(string productID, string receipt, string transactionID)
		{
			this.name = "product/buy";
			this.body = string.Empty;
			this.body = this.body + "\"productid\":\"" + productID + "\",";
			this.body = this.body + "\"receipt\":\"" + receipt + "\",";
			this.body = this.body + "\"transactionid\":\"" + transactionID + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
