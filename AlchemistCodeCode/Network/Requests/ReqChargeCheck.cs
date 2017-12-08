using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChargeCheck : WebAPI
	{
		public ReqChargeCheck(PaymentManager.Product[] products, bool isPurchase)
		{
			this.name = "charge/check";
			this.body = string.Empty;
			this.body += "\"targets\":[";
			for (int i = 0; i < products.Length; i++)
			{
				this.body += "{";
				this.body = this.body + "\"product_id\":\"" + products[i].productID + "\",";
				this.body = this.body + "\"price\":" + products[i].sellPrice;
				this.body += "}";
				if (i != products.Length - 1)
				{
					this.body += ",";
				}
			}
			this.body += "],";
			this.body += "\"currency\":\"JPY\",";
			this.body = this.body + "\"is_purchase\":" + ((!isPurchase) ? "0" : "1");
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
