using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMTurnSystem
{
    public class TurnSystemFsm : NetworkBehaviour
    {
        public static TurnSystemFsm Instance;
        
        [SerializeField] private TurnSystemAbstractState state;

        protected virtual void Start()
        {
            Instance = this;
            ChangeTurn(ScriptableObject.CreateInstance<P1State>());
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