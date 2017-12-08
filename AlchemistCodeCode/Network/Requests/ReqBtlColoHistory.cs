using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlColoHistory : WebAPI
	{
		public ReqBtlColoHistory()
		{
			this.name = "btl/colo/history/";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
