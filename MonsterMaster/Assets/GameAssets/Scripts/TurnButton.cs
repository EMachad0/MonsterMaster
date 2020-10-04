using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class TurnButton : NetworkBehaviour
    {
        public int playerIndex;
        
        private HandController _p1Hand;
        private HandController _p2Hand;
        private BoardController _p1Board;
        private BoardController _p2Board;

        private void Start()
        {
            _p1Hand = GameObject.Find("P1Hand").GetComponent<HandController>();
            _p2Hand = GameObject.Find("P2Hand").GetComponent<HandController>();
            _p1Board = GameObject.Find("P1Board").GetComponent<BoardController>();
            _p2Board = GameObject.Find("P2Board").GetComponent<BoardController>();
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