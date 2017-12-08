using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactSet : WebAPI
	{
		public ReqArtifactSet(long iid_job, long iid_artifact)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid_job\":");
			stringBuilder.Append(iid_job);
			stringBuilder.Append(",\"iid_artifact\":");
			stringBuilder.Append(iid_artifact);
			this.name = "unit/job/artifact/set";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		public ReqArtifactSet(long iid_job, long[] iid_artifact)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid_job\":");
			stringBuilder.Append(iid_job);
			stringBuilder.Append(",\"iid_artifact\":");
			stringBuilder.Append(iid_artifact[0]);
			stringBuilder.Append(",\"iid_artifacts\":[");
			for (int i = 0; i < iid_artifact.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(iid_artifact[i]);
			}
			stringBuilder.Append(']');
			this.name = "unit/job/artifact/set";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		public ReqArtifactSet(long iid_unit, long iid_job, long[] iid_artifact)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid_unit\":");
			stringBuilder.Append(iid_unit);
			stringBuilder.Append(",\"iid_job\":");
			stringBuilder.Append(iid_job);
			stringBuilder.Append(",\"iid_artifacts\":[");
			for (int i = 0; i < iid_artifact.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(iid_artifact[i]);
			}
			stringBuilder.Append(']');
			this.name = "unit/job/artifact/set";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
