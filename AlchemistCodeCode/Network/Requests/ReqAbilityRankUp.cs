using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqAbilityRankUp : WebAPI
	{
		public ReqAbilityRankUp(Dictionary<long, int> abilities, string trophyprog = null, string bingoprog = null)
		{
			this.name = "unit/job/abil/lvup";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"aps\":[");
			string text = string.Empty;
			foreach (KeyValuePair<long, int> current in abilities)
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
				text = text + "\"ap\":" + current.Value;
				text += "},";
			}
			if (text.Length > 0)
			{
				stringBuilder.Append(text.Substring(0, text.Length - 1));
			}
			stringBuilder.Append("]");
			if (!string.IsNullOrEmpty(trophyprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(trophyprog);
			}
			if (!string.IsNullOrEmpty(bingoprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(bingoprog);
			}
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
