using UnityEngine;

namespace GameAssets.Scripts.CardScripts
{
    public class CardZoom : MonoBehaviour
    {

        public float scaleSize;
        private Vector3 _scale;

        private void Start()
        {
            _scale = new Vector3(scaleSize, scaleSize, 1);
        }

        public void ZoomIn()
        {
            transform.localScale = _scale;
        }

        public void ZoomOut()
        {
            transform.localScale = Vector3.one;
        }
    }
}
