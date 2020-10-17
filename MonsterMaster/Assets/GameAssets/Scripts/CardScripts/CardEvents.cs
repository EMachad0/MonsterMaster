using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts
{
    public class CardEvents : NetworkBehaviour
    {
        public delegate void CardCollisionDelegate(GameObject a, GameObject b);
        public static event CardCollisionDelegate OnCardCollision;
        public static void CardCollision(GameObject a, GameObject b) => OnCardCollision?.Invoke(a, b);
    }
}