using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.Controllers
{
    public class SpellAssetController : AbstractAssetController
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

        protected override CardSo LoadAsset(string s) => Resources.Load<SpellCardSo>(s);

        protected override void SetAsset(CardSo so)
        {
            var c = (SpellCardSo) so;
            _cardName.text = asset;
            _sprite.sprite = c.img;
            _cardEffect.text = c.cardEffectText;
        }
    }
}