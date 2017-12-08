using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqJobAbility : WebAPI
	{
		public ReqJobAbility(long iid_job, long[] iid_abils)
		{
			this.name = "unit/job/abil/set";
			this.body = "\"iid\":" + iid_job + ",";
			this.body += "\"iid_abils\":";
			this.body += "[";
			for (int i = 0; i < iid_abils.Length; i++)
			{
				this.body += iid_abils[i].ToString();
				if (i != iid_abils.Length - 1)
				{
					this.body += ",";
				}
			}
			this.body += "]";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
