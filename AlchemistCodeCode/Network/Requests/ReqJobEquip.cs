using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqJobEquip : WebAPI
	{
		public ReqJobEquip(long iid_job, long id_equip)
		{
			this.name = "unit/job/equip/set";
			this.body = "\"iid\":" + iid_job + ",";
			this.body = this.body + "\"id_equip\":" + id_equip;
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
