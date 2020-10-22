using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using Mirror;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace GameAssets.Scripts.CardScripts.TypeBehavior
{
    public class SoLoader : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SoChange))]
        public string soName;
        
        [SerializeField] private CardSo so;

        public CardSo So => so;
        
        private void SoChange(string oldValue, string newValue)
        {
            name = newValue;
            so = ScriptableObject.CreateInstance(newValue) as CardSo;
            Debug.Assert(so != null, nameof(so) + " is null");
            so.Init(gameObject);
            CardEvents.SoChange(gameObject);
        }
    }
}