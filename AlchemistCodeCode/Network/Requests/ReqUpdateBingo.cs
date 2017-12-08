using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUpdateBingo : WebAPI
	{
		private StringBuilder sb;

		private bool is_begin;

		public ReqUpdateBingo()
		{
		}

		public ReqUpdateBingo(List<TrophyState> trophyprogs, bool finish)
		{
			this.name = "bingo/exec";
			this.BeginBingoReqString();
			this.AddBingoReqString(trophyprogs, finish);
			this.EndBingoReqString();
			this.body = WebAPI.GetRequestString(this.GetBingoReqString());
		}

		public string GetBingoReqString()
		{
			return this.sb.ToString();
		}

		public void BeginBingoReqString()
		{
			this.is_begin = true;
			this.sb = WebAPI.GetStringBuilder();
			this.sb.Append("\"bingoprogs\":[");
		}

		public void EndBingoReqString()
		{
			this.sb.Append(']');
		}

		public void AddBingoReqString(List<TrophyState> progs, bool finish)
		{
			int num = 0;
			int value = 0;
			if (finish)
			{
				value = int.Parse(DateTime.Now.ToString("yyMMdd"));
			}
			for (int i = 0; i < progs.Count; i++)
			{
				if (this.is_begin)
				{
					this.is_begin = false;
				}
				else
				{
					this.sb.Append(',');
				}
				this.sb.Append("{\"iname\":\"");
				this.sb.Append(progs[i].iname);
				this.sb.Append("\",");
				this.sb.Append("\"parent\":\"");
				if (progs[i].Param != null)
				{
					this.sb.Append(progs[i].Param.ParentTrophy);
				}
				this.sb.Append("\",");
				this.sb.Append("\"pts\":[");
				for (int j = 0; j < progs[i].Count.Length; j++)
				{
					if (j > 0)
					{
						this.sb.Append(',');
					}
					this.sb.Append(progs[i].Count[j]);
				}
				this.sb.Append("],");
				this.sb.Append("\"ymd\":");
				this.sb.Append(progs[i].StartYMD);
				if (finish)
				{
					this.sb.Append(",\"rewarded_at\":");
					this.sb.Append(value);
				}
				this.sb.Append("}");
				num++;
			}
		}
	}
}
