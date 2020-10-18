using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior
{
    public class SoLoader : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SoChange))]
        public string so;
        public CardSo cardSo;

        private void SoChange(string oldValue, string newValue)
        {
            name = newValue;
            cardSo = ScriptableObject.CreateInstance(newValue) as CardSo;
            CardEvents.SoChange(gameObject);
        }
    }
}