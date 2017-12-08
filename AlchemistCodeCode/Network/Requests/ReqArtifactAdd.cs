using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactAdd : WebAPI
	{
		public ReqArtifactAdd(string iname)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iname\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append('"');
			this.name = "unit/job/artifact/add";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
