using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class CardFlip : NetworkBehaviour
    {
        public bool isVisible;

        private GameObject _front;
        
        private void Start()
        {
            _front = transform.GetChild(1).gameObject;
            
            if (isVisible || hasAuthority) Show();
            else Hide();

            if (isClient)
            {
                var identity = NetworkClient.connection.identity;
                var cc = identity.GetComponent<ClientController>();
                if (cc.index == 1) transform.GetChild(1).Rotate(0, 0, 180);
            }
        }

        public void Flip()
        {
            if (isVisible) Hide();
            else Show();
        }

        public void Hide()
        {
            isVisible = false;
            _front.SetActive(false);
        }
        
        public void Show()
        {
            isVisible = true;
            _front.SetActive(true);
        }
    }
}