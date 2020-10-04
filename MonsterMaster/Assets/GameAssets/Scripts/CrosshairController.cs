using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class CrosshairController : NetworkBehaviour
    {
        public bool hiddenFromPlayer = true;
        private Image _img;
        
        private void Start()
        {
            _img = GetComponent<Image>();
            if (hiddenFromPlayer && isLocalPlayer) Hide();
        }
        
        private void Update()
        {
            if (isLocalPlayer)
            {
                // transform.position =  new Vector2(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y);
                transform.position =  new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }

        [Client]
        private void Hide()
        {
            _img.enabled = false;
        }
    }
}
