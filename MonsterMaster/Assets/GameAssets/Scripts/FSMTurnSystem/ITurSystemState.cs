using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public interface ITurSystemState
    {
        void StartTurn();
        bool IsMyTurn();
        void EndTurn(TurnSystemFsm fsm);
    }
}