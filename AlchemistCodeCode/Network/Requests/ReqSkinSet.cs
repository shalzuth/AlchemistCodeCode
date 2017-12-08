using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSkinSet : WebAPI
	{
		public ReqSkinSet(Dictionary<long, string> sets)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"sets\":[");
			string text = string.Empty;
			foreach (KeyValuePair<long, string> current in sets)
			{
				text += "{";
				text = text + "\"iid\":" + current.Key.ToString() + ",";
				text = text + "\"iname\":\"" + current.Value + "\"";
				text += "},";
			}
			if (text.Length > 0)
			{
				text = text.Substring(0, text.Length - 1);
			}
			stringBuilder.Append(text);
			stringBuilder.Append("]");
			this.name = "unit/skin/set";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
