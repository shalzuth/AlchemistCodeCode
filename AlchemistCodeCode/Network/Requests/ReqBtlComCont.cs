using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComCont : WebAPI
	{
		public ReqBtlComCont(long btlid, BattleCore.Record record, bool multi)
		{
			this.name = ((!multi) ? "btl/com/cont" : "btl/multi/cont");
			if (record != null)
			{
				this.body = "\"btlid\":" + btlid + ",";
				string btlEndParamString = WebAPI.GetBtlEndParamString(record, multi);
				if (!string.IsNullOrEmpty(btlEndParamString))
				{
					this.body += WebAPI.GetBtlEndParamString(record, multi);
				}
				this.body = WebAPI.GetRequestString(this.body);
			}
			else
			{
				this.body = WebAPI.GetRequestString("\"btlid\":\"" + btlid + "\"");
			}
		}
	}
}
