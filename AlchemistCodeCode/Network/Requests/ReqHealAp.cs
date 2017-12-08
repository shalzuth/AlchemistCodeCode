using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqHealAp : WebAPI
	{
		public ReqHealAp(long iid, int num)
		{
			this.name = "item/addstm";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iid\" : ");
			stringBuilder.Append(iid);
			stringBuilder.Append(",");
			stringBuilder.Append("\"num\" : ");
			stringBuilder.Append(num);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
