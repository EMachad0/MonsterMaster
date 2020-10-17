using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card/Spell", order = 0)]
    public class SpellCardSo : CardSo
    {
        public Sprite img;
        public string cardEffectText;
        
        private void OnEnable() => type = CardType.Spell;
    }
}