using GameAssets.Scripts.ClientScripts;
using Mirror;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public class P2State : PlayerTurnState
    {
        public override bool IsMyTurn()
        {
            var identity = NetworkClient.connection.identity;
            var cc =  identity.GetComponent<Client>();
            return cc.index == 1;
        }
        
        public override void EndTurn(TurnSystemFsm fsm)
        {
            fsm.ChangeTurn(CreateInstance<P1State>());
        }
        
        protected override string TurnText() => "Player's 2 turn";
    }
}