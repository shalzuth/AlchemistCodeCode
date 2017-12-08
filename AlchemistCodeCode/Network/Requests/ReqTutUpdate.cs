using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTutUpdate : WebAPI
	{
		public ReqTutUpdate(long flags)
		{
			this.name = "tut/update";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"tut\":");
			stringBuilder.Append(flags);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
