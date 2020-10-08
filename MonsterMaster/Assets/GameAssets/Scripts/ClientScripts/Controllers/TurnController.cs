using GameAssets.Scripts.FSMTurnSystem;
using Mirror;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class TurnController : NetworkBehaviour
    {
        
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
    }
}