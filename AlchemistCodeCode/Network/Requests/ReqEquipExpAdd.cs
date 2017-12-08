using System;
using System.Collections.Generic;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqEquipExpAdd : WebAPI
	{
		public ReqEquipExpAdd(long iid, int slot, Dictionary<string, int> usedItems)
		{
			this.name = "unit/job/equip/enforce";
			this.body = "\"iid\":" + iid + ",";
			string body = this.body;
			this.body = string.Concat(new object[]
			{
				body,
				"\"id_equip\":",
				slot,
				","
			});
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
