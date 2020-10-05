using TMPro;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardControllers
{
    public class MonsterCardController : CardController
    {
        private TextMeshProUGUI _cardName;
        private Image _sprite;
        private Text _def;
        private Text _atk;
        private TextMeshProUGUI _cardEffect;

        protected override void Awake()
        {
            base.Awake();
            _cardName = Front.GetChild(1).GetComponent<TextMeshProUGUI>();
            _sprite = Front.GetChild(2).GetComponent<Image>();
            _def = Front.GetChild(6).GetComponent<Text>();
            _atk = Front.GetChild(7).GetComponent<Text>();
            _cardEffect = Front.GetChild(8).GetComponent<TextMeshProUGUI>();
        }

        public override void SetCard(SoCard card)
        {
            base.SetCard(card);
            var c = (SoMonsterCard) card;
            _cardName.text = c.cardName;
            _sprite.sprite = c.img;
            _atk.text = c.atk.ToString();
            _def.text = c.def.ToString();
            _cardEffect.text = c.cardEffectText;
        }
    }
}