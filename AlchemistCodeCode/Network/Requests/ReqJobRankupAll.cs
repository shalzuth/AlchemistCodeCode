using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqJobRankupAll : WebAPI
	{
		public ReqJobRankupAll(long iid_unit, string iname_jobset)
		{
			this.name = "unit/job/equip/lvupall";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"uiid\":");
			stringBuilder.Append(iid_unit);
			stringBuilder.Append(",\"jobset\":\"");
			stringBuilder.Append(iname_jobset);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
