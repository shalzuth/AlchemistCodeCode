using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRPG;

namespace AlchemistCodeCode
{
    public class GameManager
    {
        public static GameManager Instance = new GameManager();
        public string Version = "1812";
        public string SessionID;
        public string AssetVersion;
        public string SecretKey;
        public string UdId;
        public string DeviceId;

        public PlayerData Player;
        public TowerResuponse TowerResuponse;
        public TowerFloorParam FindTowerFloor(string iname)
        {
            /*if (this.mTowerFloors != null)
            {
                for (int i = this.mTowerFloors.get_Count() - 1; i >= 0; i--)
                {
                    if (this.mTowerFloors.get_Item(i).iname == iname)
                    {
                        return this.mTowerFloors.get_Item(i);
                    }
                }
            }*/
            return null;
        }
    }
}
