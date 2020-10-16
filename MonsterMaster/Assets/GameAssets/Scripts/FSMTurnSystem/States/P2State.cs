using GameAssets.Scripts.ClientScripts;
using Mirror;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public class P2State : PlayerTurnState
    {
        public override bool IsMyTurn()
        {
            var cc = Server.LocalPlayer.GetComponent<Client>();
            return cc.index == 1;
        }
        
        public override void EndTurn(TurnSystemFsm fsm)
        {
            fsm.ChangeTurn(CreateInstance<P1State>());
        }
    }
}