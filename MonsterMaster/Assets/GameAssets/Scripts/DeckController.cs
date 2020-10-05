using UnityEngine;
using Mirror;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts
{
    public class DeckController : NetworkBehaviour
    {
        private GameObject _grid;
        private GameObject _p1Hand;
        private GameObject _p2Hand;
        
        public GameObject monsterPrefab;
        public GameObject spellPrefab;
        
        private void Start()
        {
            _grid = transform.GetChild(0).gameObject;
            _p1Hand = GameObject.Find("P1Hand");
            _p2Hand = GameObject.Find("P2Hand");
        }

        public void OnClick()
        {
            var identity = NetworkClient.connection.identity;
            var cc = identity.GetComponent<ClientController>();
            var sc = identity.GetComponent<ServerController>();

            if (_grid.transform.childCount > 0)
            {
                sc.CmdSetObjectParent(_grid.transform.GetChild(0), (cc.index == 0 ? _p1Hand : _p2Hand).transform, false);
            }
        }
    }
}
