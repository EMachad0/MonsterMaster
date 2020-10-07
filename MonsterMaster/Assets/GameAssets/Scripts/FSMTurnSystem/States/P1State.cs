using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public class P1State : TurnSystemAbstractState
    {
        private GameObject _popup;

        private void OnEnable()
        {
            _popup = PopupSpawner.Instance.FindObject("TurnPopup");
        }

        public override void StartTurn()
        {
            var txt = _popup.GetComponentInChildren<Text>();
            txt.text = "Player 1's turn";
            PopupSpawner.Instance.Spawn(_popup, 1, 2);
        }

        public override bool IsMyTurn()
        {
            var identity = NetworkClient.connection.identity;
            var cc =  identity.GetComponent<ClientController>();
            return cc.index == 0;
        }

        public override void EndTurn(TurnSystemFsm fsm)
        {
            fsm.ChangeTurn(CreateInstance<P2State>());
        }
    }
}