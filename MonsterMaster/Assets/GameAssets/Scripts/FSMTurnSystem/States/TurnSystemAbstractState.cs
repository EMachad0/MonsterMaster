using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public abstract class TurnSystemAbstractState : ScriptableObject
    {
        public virtual void StartTurn(TurnSystemFsm fsm) {}

        public virtual bool IsMyTurn() => false;

        public virtual void EndTurn(TurnSystemFsm fsm) {}
    }
}