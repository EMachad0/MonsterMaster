using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior
{
    public class StatsLoader : NetworkBehaviour
    {
        private SoLoader _soLoader;
        
        public int maxHealth;
        [SyncVar(hook = nameof(HealthChange))] public int health;
        [SyncVar(hook = nameof(AtkChange))] public int atk;
        [SyncVar(hook = nameof(DefChange))] public int def;
        public int maxSickness;
        [SyncVar(hook = nameof(SickChange))] public int sickness;

        protected virtual void Awake()
        {
            _soLoader = GetComponent<SoLoader>();
            CardEvents.OnSoChange += StatChange;
        }

        protected virtual void OnDestroy() => CardEvents.OnSoChange -= StatChange;

        private void StatChange(GameObject g)
        {
            var so = (MonsterCardSo) _soLoader.So;
            maxHealth = so.health;
            maxSickness = so.sickness;
            
            if (!isServer) return;
            health = so.health;
            atk = so.atk;
            def = so.def;
        }

        private void HealthChange(int oldValue, int newValue) => CardEvents.CardHealthChange(gameObject);
        private void AtkChange(int oldValue, int newValue) => CardEvents.CardAtkChange(gameObject);
        private void DefChange(int oldValue, int newValue) => CardEvents.CardDefChange(gameObject);
        private void SickChange(int oldValue, int newValue) => CardEvents.CardSickChange(gameObject);
    }
}