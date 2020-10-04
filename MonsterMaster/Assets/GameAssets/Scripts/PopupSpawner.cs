using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class PopupSpawner : MonoBehaviour
    {
        public static PopupSpawner Instance;

        private void Start() {
            Instance = this;
        }

        public void Spawn(GameObject g, float time)
        {
            StartCoroutine(Routine(g, time));
        }
        
        private IEnumerator Routine(GameObject g, float time)
        {
            g.SetActive(true);
            yield return new WaitForSeconds(1);

            var canvas = g.GetComponent<CanvasGroup>();
            canvas.alpha = 1;
            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / time;
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