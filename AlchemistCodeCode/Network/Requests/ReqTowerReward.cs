using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerReward : WebAPI
	{
		public ReqTowerReward(short mid, short nid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "expedition/reward";
			stringBuilder.Append("\"mid\":");
			stringBuilder.Append(mid);
			stringBuilder.Append(",");
			stringBuilder.Append("\"nid\":");
			stringBuilder.Append(nid);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
