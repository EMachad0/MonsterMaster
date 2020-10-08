using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class TurnButton : NetworkBehaviour
    {
        public int playerIndex;
        
        private Hand _p1Hand;
        private Hand _p2Hand;
        private Board _p1Board;
        private Board _p2Board;

        private void Start()
        {
            _p1Hand = GameObject.Find("P1Hand").GetComponent<Hand>();
            _p2Hand = GameObject.Find("P2Hand").GetComponent<Hand>();
            _p1Board = GameObject.Find("P1Board").GetComponent<Board>();
            _p2Board = GameObject.Find("P2Board").GetComponent<Board>();
        }

        public void OnClick()
        {
            if (!TurnSystemFsm.Instance.IsMyTurn()) return;
            UpdateCounters();
            UpdateClients();
        }

        private void UpdateCounters()
        {
        }

        private void UpdateClients()
        {
            Server.LocalPlayer.GetComponent<TurnController>().CmdEndTurn();
        }

        public void Show()
        {
            transform.localScale = Vector3.one;
        }
        
        public void Hide()
        {
            transform.localScale = Vector3.zero;
        }
    }
}