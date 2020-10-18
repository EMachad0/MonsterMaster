using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader
{
    public class MonsterAssetLoader : AbstractAssetLoader
    {
        private Transform _front;
        private Image _background;
        private TextMeshProUGUI _cardName;
        private Image _sprite;
        private Text _def;
        private Text _atk;
        private TextMeshProUGUI _cardEffect;
        private Transform _healthBar;

        protected override void GetComponents()
        {
            _front = gameObject.transform.GetChild(1);
            _background = _front.GetChild(0).GetComponent<Image>();
            _cardName = _front.GetChild(1).GetComponent<TextMeshProUGUI>();
            _sprite = _front.GetChild(2).GetComponent<Image>();
            _def = _front.GetChild(6).GetComponent<Text>();
            _atk = _front.GetChild(7).GetComponent<Text>();
            _cardEffect = _front.GetChild(8).GetComponent<TextMeshProUGUI>();
            _healthBar = _front.GetChild(9);
        }

        protected override void SetAsset(CardSo so)
        {
            var c = (MonsterCardSo) so;
            _cardName.text = c.name;
            _background.color = c.background;
            _sprite.sprite = c.img;
            _cardEffect.text = c.cardEffectText;
            _def.text = c.def.ToString();
            _atk.text = c.atk.ToString();
        }
    }
}