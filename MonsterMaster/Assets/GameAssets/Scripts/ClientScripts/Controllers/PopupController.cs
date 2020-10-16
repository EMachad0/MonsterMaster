using GameAssets.Scripts.Popups;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class PopupController : NetworkBehaviour
    {
        [Command]
        public void CmdShowPopup(GameObject g) => RpcShow(g);

        [ClientRpc]
        private void RpcShow(GameObject g) => g.GetComponent<StartPopup>().Show();
    }
}