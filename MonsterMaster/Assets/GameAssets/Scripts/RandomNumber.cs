using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class RandomNumber : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SetNumber))]
        public int value;

        private Text _text;

        private void Awake()
        {
            _text = gameObject.GetComponent<Text>();
        }

        [ServerCallback]
        public void Generate(int a, int b)
        {
            value = Random.Range(a, b);
        }

        private void SetNumber(int oldValue, int newValue)
        {
            _text.text = newValue.ToString();
        }
    }
}