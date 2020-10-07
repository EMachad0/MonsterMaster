using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class TurnButtonScript : NetworkBehaviour
    {
        public int playerIndex;
        
        private HandScript _p1Hand;
        private HandScript _p2Hand;
        private BoardScript _p1Board;
        private BoardScript _p2Board;

        private void Start()
        {
            _p1Hand = GameObject.Find("P1Hand").GetComponent<HandScript>();
            _p2Hand = GameObject.Find("P2Hand").GetComponent<HandScript>();
            _p1Board = GameObject.Find("P1Board").GetComponent<BoardScript>();
            _p2Board = GameObject.Find("P2Board").GetComponent<BoardScript>();
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
            var identity = NetworkClient.connection.identity;
            identity.GetComponent<ServerController>().CmdEndTurn();
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