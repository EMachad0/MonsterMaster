using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.Controllers
{
    public abstract class AbstractAssetController : NetworkBehaviour
    {
        [SyncVar(hook = nameof(AssetChange))]
        public string asset;
        
        [SerializeField] private CardSo cardSo;
        
        protected Transform Front;

        protected virtual void Awake()
        {
            Front = gameObject.transform.GetChild(1);
        }

        private void AssetChange(string oldValue, string newValue)
        {
            name = newValue;
            cardSo = LoadAsset(newValue);
            if (cardSo) SetAsset(cardSo);
            else Debug.LogError("Null Asset");
        }

        protected abstract CardSo LoadAsset(string s);

        protected abstract void SetAsset(CardSo so);
    }
}