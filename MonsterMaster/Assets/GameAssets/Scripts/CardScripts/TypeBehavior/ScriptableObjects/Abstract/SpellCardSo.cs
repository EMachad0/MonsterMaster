using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card/Spell", order = 0)]
    public class SpellCardSo : CardSo
    {
        public Sprite img;
        public string cardEffectText;
        
        protected virtual void OnEnable()
        {
            type = CardType.Spell;
            name = GetType().Name;
            img = Resources.Load<Sprite>(name);
        }
    }
}