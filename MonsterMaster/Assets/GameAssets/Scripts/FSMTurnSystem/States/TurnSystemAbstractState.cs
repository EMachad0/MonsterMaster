using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public abstract class TurnSystemAbstractState : ScriptableObject
    {
        public virtual void StartTurn()
        {
        }

        public virtual bool IsMyTurn()
        {
            return false;
        }

        public virtual void EndTurn(TurnSystemFsm fsm)
        {
        }
    }
}