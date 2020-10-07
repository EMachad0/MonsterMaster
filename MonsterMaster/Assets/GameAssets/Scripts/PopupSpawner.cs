using System.Collections;
using System.Linq;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class PopupSpawner : MonoBehaviour
    {
        public static PopupSpawner Instance;

        private void Start() {
            Instance = this;
        }

        public void Spawn(GameObject g, float time, float fadeout)
        {
            StartCoroutine(Routine(g, time, fadeout));
        }
        
        private IEnumerator Routine(GameObject g, float time, float fadeout)
        {
            var canvas = g.GetComponent<CanvasGroup>();
            
            g.SetActive(true);
            canvas.alpha = 1;
            yield return new WaitForSeconds(time);

            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / fadeout;
                yield return null;
            }
            g.SetActive(false);
        }
        
        public GameObject FindObject(string name)
        {
            var trs= GetComponentsInChildren<Transform>(true);
            return (from g in trs where g.name == name select g.gameObject).FirstOrDefault();
        }
    }
}