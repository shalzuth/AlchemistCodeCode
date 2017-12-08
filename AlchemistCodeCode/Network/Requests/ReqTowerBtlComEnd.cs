using GR;
using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqTowerBtlComEnd : WebAPI
	{
		public ReqTowerBtlComEnd(long btlid, Unit[] Player, Unit[] Enemy, int actCount, int round, byte floor, BtlResultTypes result, RandDeckResult[] deck, string trophyprog = null, string bingoprog = null, string maxdata = null)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "tower/btl/end";
			stringBuilder.Length = 0;
			this.SetValue(ref stringBuilder, "\"btlid\":", btlid);
			stringBuilder.Append("\"btlendparam\":{");
			if (Player != null)
			{
				stringBuilder.Append("\"pdeck\":[");
				for (int i = 0; i < Player.Length; i++)
				{
					Unit unit = Player[i];
					if (unit.Side == EUnitSide.Player && unit.UnitData.UniqueID != 0L)
					{
						stringBuilder.Append("{");
						this.SetValue(ref stringBuilder, "\"iid\":", unit.UnitData.UniqueID);
						this.SetValue(ref stringBuilder, "\"iname\":\"", unit.UnitData.UnitParam.iname, "\",");
						int num = unit.CalcTowerDamege();
						TowerFloorParam towerFloorParam = GameManager.Instance.FindTowerFloor(SceneBattle.Instance.Battle.QuestID);
						num -= towerFloorParam.CalcHelaNum(unit.MaximumStatus.param.hp);
						num = Math.Max(num, 0);
						this.SetValue(ref stringBuilder, "\"damage\":", (long)num);
						this.SetValue(ref stringBuilder, "\"is_died\":", (!unit.IsDeadCondition()) ? 0L : 1L, string.Empty);
						stringBuilder.Append("},");
					}
				}
				stringBuilder.Length--;
				stringBuilder.Append("],");
			}
			stringBuilder.Append("\"status\":\"");
			switch (result)
			{
			case BtlResultTypes.Win:
				stringBuilder.Append("win");
				break;
			case BtlResultTypes.Lose:
				stringBuilder.Append("lose");
				break;
			case BtlResultTypes.Retire:
				stringBuilder.Append("retire");
				break;
			case BtlResultTypes.Cancel:
				stringBuilder.Append("cancel");
				break;
			}
			stringBuilder.Append("\"");
			stringBuilder.Append(",\"turn\":");
			stringBuilder.Append(actCount);
			stringBuilder.Append(",\"round\":");
			stringBuilder.Append(round);
			stringBuilder.Append(",\"floor\":");
			stringBuilder.Append(floor);
			if (result == BtlResultTypes.Lose)
			{
				stringBuilder.Append(",\"edeck\":[");
				List<Unit> list = new List<Unit>(Enemy);
				list.RemoveAll((Unit x) => x.Side != EUnitSide.Enemy);
				if (GameManager.Instance.TowerResuponse.edeck != null)
				{
					List<TowerResuponse.EnemyUnit> edeck = GameManager.Instance.TowerResuponse.edeck;
					int num2 = 0;
					for (int j = 0; j < edeck.Count; j++)
					{
						if (edeck[j].hp == 0)
						{
							stringBuilder.Append("{");
							this.SetValue(ref stringBuilder, "\"eid\":\"", (long)j, "\",");
							this.SetValue(ref stringBuilder, "\"iname\":\"", edeck[j].iname, "\",");
							this.SetValue(ref stringBuilder, "\"hp\":", 0L);
							this.SetValue(ref stringBuilder, "\"jewel\":", 0L, string.Empty);
							stringBuilder.Append("},");
						}
						else
						{
							Unit unit2 = list[num2];
							num2++;
							if (unit2.Side == EUnitSide.Enemy)
							{
								stringBuilder.Append("{");
								this.SetValue(ref stringBuilder, "\"eid\":\"", (long)j, "\",");
								this.SetValue(ref stringBuilder, "\"iname\":\"", unit2.UnitParam.iname, "\",");
								this.SetValue(ref stringBuilder, "\"hp\":", (!unit2.IsDead) ? ((long)unit2.CurrentStatus.param.hp) : 0L);
								this.SetValue(ref stringBuilder, "\"jewel\":", (long)unit2.CurrentStatus.param.mp, string.Empty);
								stringBuilder.Append("},");
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < list.Count; k++)
					{
						Unit unit3 = list[k];
						if (unit3.Side == EUnitSide.Enemy)
						{
							stringBuilder.Append("{");
							this.SetValue(ref stringBuilder, "\"eid\":\"", (long)k, "\",");
							this.SetValue(ref stringBuilder, "\"iname\":\"", unit3.UnitParam.iname, "\",");
							this.SetValue(ref stringBuilder, "\"hp\":", (!unit3.IsDead) ? ((long)unit3.CurrentStatus.param.hp) : 0L);
							this.SetValue(ref stringBuilder, "\"jewel\":", (long)unit3.CurrentStatus.param.mp, string.Empty);
							stringBuilder.Append("},");
						}
					}
				}
				stringBuilder.Length--;
				stringBuilder.Append("]");
			}
			SupportData supportData = GlobalVars.SelectedSupport.Get();
			if (GlobalVars.SelectedFriendID != null && supportData != null)
			{
				stringBuilder.Append(",\"help\":{\"fuid\":\"");
				stringBuilder.Append(GlobalVars.SelectedFriendID);
				stringBuilder.Append("\",\"cost\":");
				stringBuilder.Append(supportData.Cost);
				stringBuilder.Append("}");
			}
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
			if (!string.IsNullOrEmpty(maxdata))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(maxdata);
			}
			stringBuilder.Append("}");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		public void SetValue(ref StringBuilder sb, string name, long value)
		{
			sb.Append(name);
			sb.Append(value);
			sb.Append(",");
		}

		public void SetValue(ref StringBuilder sb, string name, string value)
		{
			sb.Append(name);
			sb.Append(value);
			sb.Append(",");
		}

		public void SetValue(ref StringBuilder sb, string name, long value, string end)
		{
			sb.Append(name);
			sb.Append(value);
			sb.Append(end);
		}

		public void SetValue(ref StringBuilder sb, string name, string value, string end)
		{
			sb.Append(name);
			sb.Append(value);
			sb.Append(end);
		}
	}
}
