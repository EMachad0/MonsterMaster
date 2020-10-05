using UnityEngine;

namespace GameAssets.Scripts.CardControllers
{
    public class SoCard : ScriptableObject
    {
        public string cardName;

        private void OnEnable()
        {
            name = cardName;
        }
    }
}