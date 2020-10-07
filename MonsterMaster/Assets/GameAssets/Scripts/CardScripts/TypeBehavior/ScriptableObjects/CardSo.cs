using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    public class CardSo : ScriptableObject
    {
        public string cardName;

        private void OnEnable()
        {
            name = cardName;
        }
    }
}