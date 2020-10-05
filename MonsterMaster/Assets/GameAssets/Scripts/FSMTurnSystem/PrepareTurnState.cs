namespace GameAssets.Scripts.FSMTurnSystem
{
    public class PrepareTurnState : TurnSystemAbstractState
    {
        public override void EndTurn(TurnSystemFsm fsm)
        {
            fsm.ChangeTurn(CreateInstance<P1State>());
        }
    }
}