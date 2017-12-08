using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUnitJob : WebAPI
	{
		public ReqUnitJob(long iid_unit, long iid_job)
		{
			this.Setup(iid_unit, iid_job, null);
		}

		public ReqUnitJob(long iid_unit, long iid_job, string ptype)
		{
			this.Setup(iid_unit, iid_job, ptype);
		}

		private void Setup(long iid_unit, long iid_job, string ptype)
		{
			this.name = "unit/job/set";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\":");
			stringBuilder.Append(iid_unit);
			stringBuilder.Append(",\"iid_job\":");
			stringBuilder.Append(iid_job);
			if (!string.IsNullOrEmpty(ptype))
			{
				stringBuilder.Append(",\"type\":\"");
				stringBuilder.Append(ptype);
				stringBuilder.Append('"');
			}
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
