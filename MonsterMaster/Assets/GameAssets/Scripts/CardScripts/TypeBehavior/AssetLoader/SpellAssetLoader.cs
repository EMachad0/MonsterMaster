using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader
{
    public class SpellAssetLoader : AbstractAssetLoader
    {
        private Transform _front;
        private Image _sprite;
        private TextMeshProUGUI _cardName;
        private TextMeshProUGUI _cardEffect;
        
        protected override void GetComponents()
        {
            _front = gameObject.transform.GetChild(1);
            _sprite = _front.GetChild(0).GetComponent<Image>();
            _cardName = _front.GetChild(1).GetComponent<TextMeshProUGUI>();
            _cardEffect = _front.GetChild(2).GetComponent<TextMeshProUGUI>();
        }

        protected override void SetAsset(CardSo so)
        {
            var c = (SpellCardSo) so;
            _cardName.text = c.name;
            _sprite.sprite = c.img;
            _cardEffect.text = c.cardEffectText;
        }
    }
}