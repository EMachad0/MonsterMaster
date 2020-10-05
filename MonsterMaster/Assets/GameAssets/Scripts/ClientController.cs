using UnityEngine;
using Mirror;

namespace GameAssets.Scripts
{
    public class ClientController : NetworkBehaviour
    {
        [SyncVar]
        public int index = -1;

        private GameObject _canvas;
        
        private void Start()
        {
            _canvas = GameObject.Find("Canvas");
            
            ClientCreate();
            name = "P" + index;
        }

        [ClientCallback]
        private void ClientCreate()
        {
            if (!isLocalPlayer) return;
            switch (index)
            {
                case 0:
                    P1Config();
                    break;
                case 1:
                    P2Config();
                    break;
                default:
                    Debug.Log("Player with invalid index");
                    break;
            }
        }

        private void P1Config()
        {
        }
        
        private void P2Config()
        {
            _canvas.transform.Rotate(new Vector3(0, 0, 180));
        }
        
        public void SetIndex(int v)
        {
            index = v;
            name = "P" + index;
        }
    }
}