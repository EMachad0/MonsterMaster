using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.Controllers
{
    public abstract class CardController : NetworkBehaviour
    {
        public CardSo cardSo;

        protected Transform Front;

        protected virtual void Awake()
        {
            Front = gameObject.transform.GetChild(1);
        }

        public virtual void SetCard(CardSo card)
        {
            cardSo = card;
        }
    }
}