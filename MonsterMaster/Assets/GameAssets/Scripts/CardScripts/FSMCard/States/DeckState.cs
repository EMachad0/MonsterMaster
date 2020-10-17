namespace GameAssets.Scripts.CardScripts.FSMCard.States
{
    public class DeckState : CardAbstractState
    {
        public override void EndState(CardFsm fsm)
        {
            fsm.ChangeState(CreateInstance<HandState>());
        }
    }
}