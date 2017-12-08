using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSellPiece : WebAPI
	{
		public ReqSellPiece(Dictionary<long, int> sells)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"sells\":[");
			string text = string.Empty;
			foreach (KeyValuePair<long, int> current in sells)
			{
				text += "{";
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\"iid\":",
					current.Key,
					","
				});
				text = text + "\"num\":" + current.Value;
				text += "},";
			}
			if (text.Length > 0)
			{
				text = text.Substring(0, text.Length - 1);
			}
			stringBuilder.Append(text);
			stringBuilder.Append("]");
			this.name = "shop/piece/sell";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
