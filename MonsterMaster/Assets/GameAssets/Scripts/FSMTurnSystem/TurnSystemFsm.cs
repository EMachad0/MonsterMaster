using System;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public class TurnSystemFsm : NetworkBehaviour
    {
        public static TurnSystemFsm Instance;

        [SerializeField] private TurnSystemAbstractState state;

        protected virtual void Awake()
        {
            Instance = this;
            ChangeTurn(ScriptableObject.CreateInstance<PrepareTurnState>());
        }
        
        public void ChangeTurn(TurnSystemAbstractState novo)
        {
            state = novo;
            state.StartTurn();
        }

        public bool IsMyTurn()
        {
            return state.IsMyTurn();
        }

        public void EndTurn()
        {
            state.EndTurn(this);
        }
    }
}