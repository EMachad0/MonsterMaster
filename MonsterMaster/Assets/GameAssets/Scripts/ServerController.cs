using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class ServerController : NetworkBehaviour
    {
        public GameObject card;

        [Command]
        public void CmdSpawnCard(GameObject parent)
        {
            var c = Instantiate(card, parent.transform, false);
            NetworkServer.Spawn(c, connectionToClient);
            RpcSetObjectParent(c.transform, parent.transform, false);
        }

        [Command]
        public void CmdSetObjectParent(Transform g, Transform parent, bool worldPosStay)
        {
            g.SetParent(parent, worldPosStay);
            RpcSetObjectParent(g, parent, worldPosStay);
        }
        
        [ClientRpc]
        private void RpcSetObjectParent(Transform g, Transform parent, bool worldPosStay)
        {
            g.SetParent(parent, worldPosStay);
        }

        [Command]
        public void CmdDestroy(GameObject g)
        {
            NetworkServer.Destroy(g);
        }

        [Command]
        public void CmdEndTurn()
        {
            RpcEndTurn();
        } 
        
        [ClientRpc]
        private void RpcEndTurn()
        {
            TurnSystemFsm.Instance.EndTurn();
        }

        [Command]
        public void CmdSetVisibility(GameObject g, bool visibility)
        {
            RpcSetVisibility(g, visibility);
        }
        
        [ClientRpc]
        private void RpcSetVisibility(GameObject g, bool visibility)
        {
            var cardFlip = g.GetComponent<CardFlip>();
            if (visibility) cardFlip.Show();
            else cardFlip.Hide();
        }
    }
}