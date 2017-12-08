using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUpdateTrophy : WebAPI
	{
		private StringBuilder sb;

		private bool is_begin;

		public ReqUpdateTrophy()
		{
		}

		public ReqUpdateTrophy(List<TrophyState> trophyprogs, bool finish)
		{
			this.name = "trophy/exec";
			this.BeginTrophyReqString();
			this.AddTrophyReqString(trophyprogs, finish);
			this.EndTrophyReqString();
			this.body = WebAPI.GetRequestString(this.GetTrophyReqString());
		}

		public string GetTrophyReqString()
		{
			return this.sb.ToString();
		}

		public void BeginTrophyReqString()
		{
			this.is_begin = true;
			this.sb = WebAPI.GetStringBuilder();
			this.sb.Append("\"trophyprogs\":[");
		}

		public void EndTrophyReqString()
		{
			this.sb.Append(']');
		}

		public void AddTrophyReqString(List<TrophyState> trophyprogs, bool finish)
		{
			int num = 0;
			int value = 0;
			if (finish)
			{
				value = int.Parse(DateTime.Now.ToString("yyMMdd"));
			}
			for (int i = 0; i < trophyprogs.Count; i++)
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
				this.sb.Append(trophyprogs[i].iname);
				this.sb.Append("\",");
				this.sb.Append("\"pts\":[");
				for (int j = 0; j < trophyprogs[i].Count.Length; j++)
				{
					if (j > 0)
					{
						this.sb.Append(',');
					}
					this.sb.Append(trophyprogs[i].Count[j]);
				}
				this.sb.Append("],");
				this.sb.Append("\"ymd\":");
				this.sb.Append(trophyprogs[i].StartYMD);
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
