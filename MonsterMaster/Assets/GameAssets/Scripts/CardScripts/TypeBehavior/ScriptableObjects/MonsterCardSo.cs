using System;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card/Monster", order = 0)]
    public class MonsterCardSo : CardSo
    {
        public Color background;
        public Sprite img;
        public int health;
        public int atk;
        public int def;
        public string cardEffectText;
        public int sickness;

        private void OnEnable() => type = CardType.Monster;
    }
}