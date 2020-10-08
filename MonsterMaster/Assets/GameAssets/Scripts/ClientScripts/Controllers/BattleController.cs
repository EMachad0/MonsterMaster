using GameAssets.Scripts.Popups;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class BattleController : NetworkBehaviour
    {
        private BattleSystem _popup;
        
        private void Awake()
        {
            var popupSpawner = GameObject.Find("Popups").GetComponent<PopupSpawner>();
            _popup = popupSpawner.FindObject("BattlePopup").GetComponent<BattleSystem>();
        }

        [Command]
        public void CmdShowBattle(GameObject c1, GameObject c2)
        {
            RpcShowBattle(c1, c2);
        }

        [ClientRpc]
        private void RpcShowBattle(GameObject c1, GameObject c2)
        {
            _popup.StartBattle(c1, c2);
        }
    }
}