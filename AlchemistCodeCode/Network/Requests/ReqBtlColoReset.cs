using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlColoReset : WebAPI
	{
		public ReqBtlColoReset(ColoResetTypes reset)
		{
			this.name = "btl/colo/reset/" + reset.ToString();
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
