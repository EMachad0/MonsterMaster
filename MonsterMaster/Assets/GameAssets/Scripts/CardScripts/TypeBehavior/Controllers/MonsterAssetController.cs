using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.Controllers
{
    public class MonsterAssetController : AbstractAssetController
    {
        private Image _background;
        private TextMeshProUGUI _cardName;
        private Image _sprite;
        private Text _def;
        private Text _atk;
        private TextMeshProUGUI _cardEffect;
        private Transform _healthBar;
        
        [SerializeField] private int maxHealth;
        [SerializeField] private int curHealth;

        protected override void Awake()
        {
            base.Awake();
            _background = Front.GetChild(0).GetComponent<Image>();
            _cardName = Front.GetChild(1).GetComponent<TextMeshProUGUI>();
            _sprite = Front.GetChild(2).GetComponent<Image>();
            _def = Front.GetChild(6).GetComponent<Text>();
            _atk = Front.GetChild(7).GetComponent<Text>();
            _cardEffect = Front.GetChild(8).GetComponent<TextMeshProUGUI>();
            _healthBar = Front.GetChild(9);
        }
        
        protected override CardSo LoadAsset(string s) => Resources.Load<MonsterCardSo>(s);

        protected override void SetAsset(CardSo so)
        {
            var c = (MonsterCardSo) so;
            _cardName.text = asset;
            _background.color = c.background;
            _sprite.sprite = c.img;
            _atk.text = c.atk.ToString();
            _def.text = c.def.ToString();
            _cardEffect.text = c.cardEffectText;

            maxHealth = c.health;
            curHealth = c.health;
            for (var i = maxHealth; i < 10; i++)
            {
                _healthBar.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}