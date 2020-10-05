using UnityEngine;

namespace GameAssets.Scripts.CardControllers
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card/Spell", order = 0)]
    public class SoSpellCard : SoCard
    {
        public Sprite img;
        public string cardEffectText;
    }
}