using UnityEngine;
using Mirror;

namespace GameAssets.Scripts
{
    public class DeckController : NetworkBehaviour
    {
        private GameObject _p1Hand;
        private GameObject _p2Hand;

        private void Start()
        {
            _p1Hand = GameObject.Find("P1Hand");
            _p2Hand = GameObject.Find("P2Hand");
        }
        
        [ClientCallback]
        public void OnClick()
        {
            var identity = NetworkClient.connection.identity;
            var cc = identity.GetComponent<ClientController>();
            var sc = identity.GetComponent<ServerController>();
            sc.CmdSpawnCard(cc.index == 0 ?  _p1Hand:_p2Hand);
        }
    }
}
