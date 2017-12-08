using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlColoRanking : WebAPI
	{
		public enum RankingTypes
		{
			world,
			friend
		}

		public ReqBtlColoRanking(ReqBtlColoRanking.RankingTypes type)
		{
			this.name = "btl/colo/ranking/" + type.ToString();
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
