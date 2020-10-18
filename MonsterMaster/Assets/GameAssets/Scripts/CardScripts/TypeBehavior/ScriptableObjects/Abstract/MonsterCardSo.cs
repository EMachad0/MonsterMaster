using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract
{
    public class MonsterCardSo : CardSo
    {
        public Color background;
        public Sprite img;
        public int maxHealth;
        [SyncVar] public int health;
        [SyncVar] public int atk;
        [SyncVar] public int def;
        public string cardEffectText;
        public int sickness;

        protected virtual void OnEnable()
        {
            type = CardType.Monster;
            name = GetType().Name;
            img = Resources.Load<Sprite>(name);
        }
    }
}