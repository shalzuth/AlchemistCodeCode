using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerReset : WebAPI
	{
		public ReqTowerReset(string qid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"qid\":\"");
			stringBuilder.Append(qid);
			stringBuilder.Append("\"");
			this.name = "tower/reset";
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
