using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public abstract class TurnSystemAbstractState : ScriptableObject, ITurSystemState
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