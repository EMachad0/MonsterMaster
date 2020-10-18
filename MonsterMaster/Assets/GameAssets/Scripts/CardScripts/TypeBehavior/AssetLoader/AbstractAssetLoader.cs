using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader
{
    public abstract class AbstractAssetLoader : NetworkBehaviour
    {
        private SoLoader _soLoader;
        
        protected virtual void Awake()
        {
            _soLoader = GetComponent<SoLoader>();
            GetComponents();
            CardEvents.OnSoChange += AssetChange;
        }

        protected virtual void OnDestroy() => CardEvents.OnSoChange -= AssetChange;

        private void AssetChange(GameObject g)
        {
            if (g != gameObject) return;
            var cardSo = _soLoader.cardSo;
            if (cardSo) SetAsset(cardSo);
            else Debug.LogError("Null Asset");
        }

        protected abstract void GetComponents();

        protected abstract void SetAsset(CardSo so);
    }
}