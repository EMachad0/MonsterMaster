using System.Collections;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.Popups
{
    public class TurnStartPopup : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        
        private CanvasGroup _canvas;
        
        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
        }
        
        private void Start()
        {
            StartCoroutine(ShowRoutine());
            // gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvas.alpha = 1;

            StartCoroutine(ShowRoutine());
        }
        
        private IEnumerator ShowRoutine()
        {
            yield return new WaitForSeconds(time);

            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= Time.deltaTime / fadeoutTime;
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}