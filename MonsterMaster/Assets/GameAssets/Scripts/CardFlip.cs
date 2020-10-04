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