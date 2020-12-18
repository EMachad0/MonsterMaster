using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader
{
    public class MonsterAssetLoader : AbstractAssetLoader
    {
        private StatsLoader _stats;
        
        private Transform _front;
        private Image _background;
        private TextMeshProUGUI _cardName;
        private Image _sprite;
        private TextMeshProUGUI _cardEffect;
        private Text _def;
        private Text _atk;
        private Transform _healthBar;

        protected override void Awake()
        {
            base.Awake();
            _stats = GetComponent<StatsLoader>();
            CardEvents.OnCardHealthChange += OnCardHealthChange;
            CardEvents.OnCardAtkChange += OnCardAtkChange;
            CardEvents.OnCardDefChange += OnCardDefChange;
        }

        protected override void OnDestroy()
        {
            CardEvents.OnCardHealthChange -= OnCardHealthChange;
            CardEvents.OnCardAtkChange -= OnCardAtkChange;
            CardEvents.OnCardDefChange -= OnCardDefChange;
        }

        private void OnCardHealthChange(GameObject g)
        {
            if (g != gameObject) return;
            for (var i = 0; i < _healthBar.transform.childCount; i++)
            {
                _healthBar.GetChild(i).gameObject.SetActive(i < _stats.health);
            }
        }

        private void OnCardAtkChange(GameObject g)
        {
            if (g != gameObject) return;
            _atk.text = _stats.atk.ToString();
        }

        private void OnCardDefChange(GameObject g)
        {
            if (g != gameObject) return;
            _def.text = _stats.def.ToString();
        }


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
        }
    }
}