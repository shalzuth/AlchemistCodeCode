using GR;
using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqParty : WebAPI
	{
		public ReqParty(bool needUpdateMultiRoom = false, bool ignoreEmpty = true)
		{
			List<PartyData> partys = GameManager.Instance.Player.Partys;
			this.name = "party2";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"parties\":[");
			int num = 0;
			for (int i = 0; i < partys.Count; i++)
			{
				if (!ignoreEmpty || partys[i].Num != 0)
				{
					if (num > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append("{\"units\":[");
					for (int j = 0; j < partys[i].MAX_UNIT; j++)
					{
						if (j > 0)
						{
							stringBuilder.Append(',');
						}
						stringBuilder.Append(partys[i].GetUnitUniqueID(j));
					}
					stringBuilder.Append(']');
					string stringFromPartyType = PartyData.GetStringFromPartyType((PlayerPartyTypes)i);
					stringBuilder.Append(",\"ptype\":\"");
					stringBuilder.Append(stringFromPartyType);
					stringBuilder.Append('"');
					stringBuilder.Append('}');
					num++;
				}
			}
			stringBuilder.Append(']');
			if (needUpdateMultiRoom)
			{
				stringBuilder.Append(",\"roomowner\":1");
				DebugUtility.Log("UpdateMulti!");
			}
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
