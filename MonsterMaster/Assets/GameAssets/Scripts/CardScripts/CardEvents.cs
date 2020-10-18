using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts
{
    public abstract class CardEvents
    {
        public delegate void CardCollisionDelegate(GameObject a, GameObject b);
        public static event CardCollisionDelegate OnCardCollision;
        public static void CardCollision(GameObject a, GameObject b) => OnCardCollision?.Invoke(a, b);
        
        public delegate void CardAtkChangeDelegate(GameObject a, GameObject b);
        public static event CardAtkChangeDelegate OnCardAtkChange;
        public static void CardAtkChange(GameObject a, GameObject b) => OnCardAtkChange?.Invoke(a, b);
        
        public delegate void SoChangeDelegate(GameObject g);
        public static event SoChangeDelegate OnSoChange;
        public static void SoChange(GameObject g) => OnSoChange?.Invoke(g);
    }
}