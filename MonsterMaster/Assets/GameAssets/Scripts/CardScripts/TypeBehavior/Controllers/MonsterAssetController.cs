using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects;
using Mirror;
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
        
        [Range(0, 10)] public int maxHealth;
        
        [Range(0, 10), SyncVar(hook = nameof(UpdateHealth))]
        public int curHealth = 10;
        
        [SyncVar(hook = nameof(UpdateAttack))]
        public int attack;
        
        [SyncVar(hook = nameof(UpdateDefense))]
        public int defense;

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
            _cardEffect.text = c.cardEffectText;

            maxHealth = c.health;

            if (isServer)
            {
                attack = c.atk;
                defense = c.def;
                curHealth = c.health;
            }
        }

        private void UpdateHealth(int oldValue, int newValue)
        {
            for (var i = 0; i < 10; i++)
            {
                _healthBar.GetChild(i).gameObject.SetActive(i < newValue);
            }
        }

        private void UpdateAttack(int oldValue, int newValue) => _atk.text = newValue.ToString();
        private void UpdateDefense(int oldValue, int newValue) => _def.text = newValue.ToString();
    }
}