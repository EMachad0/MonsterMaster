using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class Zoom : MonoBehaviour
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
