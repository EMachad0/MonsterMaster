using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader
{
    public abstract class AbstractAssetLoader : NetworkBehaviour
    {
        protected SoLoader SoLoader;
        
        protected virtual void Awake()
        {
            SoLoader = GetComponent<SoLoader>();
            GetComponents();
            CardEvents.OnSoChange += AssetChange;
        }

        protected virtual void OnDestroy() => CardEvents.OnSoChange -= AssetChange;

        private void AssetChange(GameObject g)
        {
            if (g != gameObject) return;
            var cardSo = SoLoader.So;
            if (cardSo) SetAsset(cardSo);
            else Debug.LogError("Null Asset");
        }

        protected abstract void GetComponents();

        protected abstract void SetAsset(CardSo so);
    }
}