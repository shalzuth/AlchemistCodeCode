using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqArtifactConvert : WebAPI
	{
		public ReqArtifactConvert(long[] artifact_iids)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iids\":[");
			string text = string.Empty;
			for (int i = 0; i < artifact_iids.Length; i++)
			{
				text = text + artifact_iids[i].ToString() + ",";
			}
			if (text.Length > 0)
			{
				text = text.Substring(0, text.Length - 1);
			}
			stringBuilder.Append(text);
			stringBuilder.Append("]");
			this.name = "unit/job/artifact/convert";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
