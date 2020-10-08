using GameAssets.Scripts.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public abstract class PlayerTurnState : TurnSystemAbstractState
    {
        private TurnStartPopup _popup;

        private void OnEnable()
        {
            var popupSpawner = GameObject.Find("Popups").GetComponent<PopupSpawner>();
            _popup = popupSpawner.FindObject("TurnPopup").GetComponent<TurnStartPopup>();
        }

        public override void StartTurn()
        {
            var txt = _popup.GetComponentInChildren<Text>();
            txt.text = TurnText();
            _popup.Show();
        }

        protected abstract string TurnText();
    }
}