using TMPro;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardControllers
{
    public class SpellCardController : CardController
    {
        private Image _sprite;
        private TextMeshProUGUI _cardName;
        private TextMeshProUGUI _cardEffect;
        
        protected override void Awake()
        {
            base.Awake();
            _sprite = Front.GetChild(0).GetComponent<Image>();
            _cardName = Front.GetChild(1).GetComponent<TextMeshProUGUI>();
            _cardEffect = Front.GetChild(2).GetComponent<TextMeshProUGUI>();
        }

        public override void SetCard(SoCard card)
        {
            base.SetCard(card);
            var c = (SoSpellCard) card;
            _sprite.sprite = c.img;
            _cardName.text = c.cardName;
            _cardEffect.text = c.cardEffectText;
        }
    }
}