using System;
using System.Collections.Generic;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqItemSell : WebAPI
	{
		public ReqItemSell(Dictionary<long, int> sells)
		{
			this.name = "item/sell";
			this.body = "\"sells\":[";
			string text = string.Empty;
			foreach (KeyValuePair<long, int> current in sells)
			{
				text += "{";
				text = text + "\"iid\":" + current.Key.ToString() + ",";
				text = text + "\"num\":" + current.Value.ToString();
				text += "},";
			}
			if (text.Length > 0)
			{
				text = text.Substring(0, text.Length - 1);
			}
			this.body += text;
			this.body += "]";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
