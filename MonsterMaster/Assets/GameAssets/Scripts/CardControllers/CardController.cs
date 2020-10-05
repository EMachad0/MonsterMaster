using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardControllers
{
    public abstract class CardController : NetworkBehaviour
    {
        public SoCard soCard;

        protected Transform Front;

        protected virtual void Awake()
        {
            Front = gameObject.transform.GetChild(1);
        }

        public virtual void SetCard(SoCard card)
        {
            soCard = card;
        }
    }
}