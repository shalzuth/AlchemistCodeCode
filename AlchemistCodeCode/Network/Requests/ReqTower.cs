using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTower : WebAPI
	{
		public ReqTower(string questID)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "tower";
			stringBuilder.Append("\"qid\":\"");
			stringBuilder.Append(questID);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
