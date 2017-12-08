using System;
using System.Collections.Generic;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUnitExpAdd : WebAPI
	{
		public ReqUnitExpAdd(long iid, Dictionary<string, int> usedItems)
		{
			this.name = "unit/exp/add";
			this.body = "\"iid\":" + iid + ",";
			this.body += "\"mats\":[";
			string text = string.Empty;
			foreach (KeyValuePair<string, int> current in usedItems)
			{
				text += "{";
				text = text + "\"iname\":\"" + current.Key + "\",";
				text = text + "\"num\":" + current.Value;
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
