using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerRank : WebAPI
	{
		public class JSON_TowerRankParam
		{
			public string fuid;

			public string name;

			public int lv;

			public int rank;

			public int score;

			public string uid;

			public Json_Unit unit;
		}

		public class JSON_TowerRankResponse
		{
			public ReqTowerRank.JSON_TowerRankParam[] speed;

			public ReqTowerRank.JSON_TowerRankParam[] technical;
		}

		public ReqTowerRank(string qid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "tower/ranking";
			stringBuilder.Append("\"qid\":\"");
			stringBuilder.Append(qid);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
