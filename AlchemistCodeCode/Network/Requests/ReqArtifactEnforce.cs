using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactEnforce : WebAPI
	{
		public ReqArtifactEnforce(long iid, Dictionary<string, int> usedItems)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\":");
			stringBuilder.Append(iid);
			stringBuilder.Append(",\"mats\":[");
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
			stringBuilder.Append(text);
			stringBuilder.Append("]");
			this.name = "unit/job/artifact/enforce";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
