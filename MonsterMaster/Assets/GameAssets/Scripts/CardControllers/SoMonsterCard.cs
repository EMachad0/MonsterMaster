using UnityEngine;

namespace GameAssets.Scripts.CardControllers
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card/Monster", order = 0)]
    public class SoMonsterCard : SoCard
    {
        public Sprite img;
        public int health;
        public int atk;
        public int def;
        public string cardEffectText;
    }
}