using System;
using GameAssets.Scripts.CardScripts.FSMCard.States;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.FSMCard
{
    [Serializable]
    public class CardFsm : NetworkBehaviour
    {
        public CardAbstractState state;
        
        protected void Awake()
        {
            ChangeState(ScriptableObject.CreateInstance<DeckState>());
        }

        public void ChangeState(CardAbstractState novo)
        {
            state = novo;
            state.StartState(this);
        }
        
        private bool IsDraggable()
        {
            return hasAuthority && TurnSystemFsm.Instance.IsMyTurn();
        }

        public void BeginDrag()
        {
            if (!IsDraggable()) return;
            state.BeginDrag(this);
        }

        public void Drag()
        {
            if (!IsDraggable()) return;
            state.Drag(this);
        }

        public void EndDrag()
        {
            if (!IsDraggable()) return;
            state.EndDrag(this);
        }

        public void OnCollisionEnter2D(Collision2D collision) => state.OnCollisionEnter2D(collision);

        public void OnCollisionExit2D(Collision2D collision) => state.OnCollisionExit2D(collision);

        public virtual void StartState() => state.StartState(this);

        public virtual void EndState() => state.EndState(this);
    }
}