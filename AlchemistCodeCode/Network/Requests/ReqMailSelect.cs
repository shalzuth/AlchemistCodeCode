using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqMailSelect : WebAPI
	{
		public enum type : byte
		{
			item,
			unit,
			artifact
		}

		public ReqMailSelect(string ticketid, ReqMailSelect.type type)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "mail/select";
			stringBuilder.Append("\"iname\" : \"");
			stringBuilder.Append(ticketid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"type\" : \"");
			switch (type)
			{
			case ReqMailSelect.type.item:
				stringBuilder.Append("item");
				break;
			case ReqMailSelect.type.unit:
				stringBuilder.Append("unit");
				break;
			case ReqMailSelect.type.artifact:
				stringBuilder.Append("artifact");
				break;
			}
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
