using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerRecover : WebAPI
	{
		public ReqTowerRecover(string qid, int coin, int round, byte floor)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "tower/recover";
			stringBuilder.Append("\"qid\":\"");
			stringBuilder.Append(qid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"coin\":");
			stringBuilder.Append(coin);
			stringBuilder.Append(",");
			stringBuilder.Append("\"round\":");
			stringBuilder.Append(round);
			stringBuilder.Append(",");
			stringBuilder.Append("\"floor\":");
			stringBuilder.Append(floor);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
