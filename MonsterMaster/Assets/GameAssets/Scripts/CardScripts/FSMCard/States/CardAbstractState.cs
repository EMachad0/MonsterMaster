using UnityEngine;

namespace GameAssets.Scripts.CardScripts.FSMCard.States
{
    public class CardAbstractState : ScriptableObject
    {
        public virtual void BeginDrag(CardFsm fsm)
        {
        }

        public virtual void Drag(CardFsm fsm)
        {
        }

        public virtual void EndDrag(CardFsm fsm)
        {
        }

        public virtual void OnCollisionEnter2D(Collision2D collision2D)
        {
        }

        public virtual void OnCollisionExit2D(Collision2D collision2D)
        {
        }

        public virtual void StartState(CardFsm fsm)
        {
        }

        public virtual void EndState(CardFsm fsm)
        {
        }
    }
}