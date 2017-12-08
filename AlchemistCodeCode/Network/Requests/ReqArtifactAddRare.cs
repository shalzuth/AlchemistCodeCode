using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactAddRare : WebAPI
	{
		public ReqArtifactAddRare(long iid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\":");
			stringBuilder.Append(iid);
			this.name = "unit/job/artifact/rare/add";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
