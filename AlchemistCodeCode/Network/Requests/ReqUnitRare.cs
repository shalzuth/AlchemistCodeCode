using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqUnitRare : WebAPI
	{
		public ReqUnitRare(long iid, string trophyprog = null, string bingoprog = null)
		{
			this.name = "unit/rare/add";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\":" + iid);
			if (!string.IsNullOrEmpty(trophyprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(trophyprog);
			}
			if (!string.IsNullOrEmpty(bingoprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(bingoprog);
			}
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
