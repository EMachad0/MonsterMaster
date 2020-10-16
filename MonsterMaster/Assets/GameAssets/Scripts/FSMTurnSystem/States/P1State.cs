using GameAssets.Scripts.ClientScripts;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public class P1State : PlayerTurnState
    {
        public override bool IsMyTurn()
        {
            var cc = Server.LocalPlayer.GetComponent<Client>();
            return cc.index == 0;
        }

        public override void EndTurn(TurnSystemFsm fsm)
        {
            fsm.ChangeTurn(CreateInstance<P2State>());
        }
    }
}