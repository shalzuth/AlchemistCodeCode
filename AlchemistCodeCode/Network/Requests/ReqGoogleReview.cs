using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGoogleReview : WebAPI
	{
		public ReqGoogleReview()
		{
			this.name = "serial/register/greview";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
