using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts
{
    public class Client : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SetIndex))]
        public int index = -1;

        private GameObject _canvas;

        private void Awake()
        {
            _canvas = GameObject.Find("Canvas");
        }

        public override void OnStartLocalPlayer()
        {
            switch (index)
            {
                case 0:
                    P1Config();
                    break;
                case 1:
                    P2Config();
                    break;
                default:
                    Debug.LogError("Player with invalid index");
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
        
        public void SetIndex(int oldValue, int newValue)
        {
            name = "P" + newValue;
        }
    }
}