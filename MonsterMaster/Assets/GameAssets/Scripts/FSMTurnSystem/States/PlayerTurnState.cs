using GameAssets.Scripts.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.FSMTurnSystem.States
{
    public abstract class PlayerTurnState : TurnSystemAbstractState
    {
        // private StartPopup _popup;

        // private void OnEnable()
        // {
        //     var popupSpawner = GameObject.Find("Popups").GetComponent<PopupSpawner>();
        //     _popup = popupSpawner.FindObject("TurnPopup").GetComponent<StartPopup>();
        // }

        // public override void StartTurn(TurnSystemFsm fsm)
        // {
        //     var txt = _popup.GetComponentInChildren<Text>();
        //     txt.text = TurnText();
        //     _popup.Show();
        // }
        //
        // protected abstract string TurnText();
    }
}