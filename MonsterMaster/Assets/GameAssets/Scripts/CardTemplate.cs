using System;
using UnityEngine;

namespace GameAssets.Scripts
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 0)]
    public class CardTemplate : ScriptableObject
    {
        public string cardName;
        public Sprite img;
        public int health;
        public int atk;
        public int def;

        private void OnEnable()
        {
            name = cardName;
        }
    }
}