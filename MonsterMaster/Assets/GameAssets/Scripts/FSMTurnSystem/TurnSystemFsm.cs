using GameAssets.Scripts.FSMTurnSystem.States;
using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public class TurnSystemFsm : MonoBehaviour
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