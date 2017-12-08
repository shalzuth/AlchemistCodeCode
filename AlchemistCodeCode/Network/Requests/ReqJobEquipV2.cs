using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqJobEquipV2 : WebAPI
	{
		public ReqJobEquipV2(long iid_unit, string iname_jobset, long slot)
		{
			this.name = "unit/job/equip/set2";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\":");
			stringBuilder.Append(iid_unit);
			stringBuilder.Append(",\"iname\":\"");
			stringBuilder.Append(iname_jobset);
			stringBuilder.Append("\"");
			stringBuilder.Append(",\"slot\":");
			stringBuilder.Append(slot);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
