using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqJobRankup : WebAPI
	{
		public ReqJobRankup(long iid_job)
		{
			this.name = "unit/job/equip/lvup/";
			this.body = WebAPI.GetRequestString("\"iid\":" + iid_job);
		}
	}
}
