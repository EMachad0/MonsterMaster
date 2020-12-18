using System;
using GameAssets.Scripts.FSMTurnSystem.States;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public class TurnSystemFsm : NetworkBehaviour
    {
        public static TurnSystemFsm Instance;

        [SerializeField] private TurnSystemAbstractState state;

        protected void Awake()
        {
            Instance = this;
            ChangeTurn(ScriptableObject.CreateInstance<PrepareTurnState>());
        }
        
        public void ChangeTurn(TurnSystemAbstractState novo)
        {
            state = novo;
            StartTurn();
        }

        public bool IsMyTurn() => state.IsMyTurn();

        public void StartTurn()
        {
            state.StartTurn(this);
            OnStartTurn?.Invoke();
        }

        public void EndTurn()
        {
            state.EndTurn(this);
            OnEndTurn?.Invoke();
        }
        
        public static event Action OnStartTurn;
        public static event Action OnEndTurn;
    }
}