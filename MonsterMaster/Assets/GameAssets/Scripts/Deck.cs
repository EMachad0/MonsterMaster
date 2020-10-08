using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using UnityEngine;
using Mirror;

namespace GameAssets.Scripts
{
    public class Deck : NetworkBehaviour
    {
        private GameObject _grid;
        private GameObject _p1Hand;
        private GameObject _p2Hand;
        
        private void Start()
        {
            _grid = transform.GetChild(0).gameObject;
            _p1Hand = GameObject.Find("P1Hand");
            _p2Hand = GameObject.Find("P2Hand");
        }

        public void OnClick()
        {
            var client = Server.LocalPlayer.GetComponent<Client>();
            var cardController = Server.LocalPlayer.GetComponent<CardController>();

            if (_grid.transform.childCount <= 0) return;
            var card = _grid.transform.GetChild(0).gameObject;
            cardController.CmdEndState(card);
            cardController.CmdCardParent(card, client.index == 0 ? _p1Hand : _p2Hand, false);
        }
    }
}
