using System;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts
{
    public abstract class CardEvents
    {
        public static event Action<GameObject, GameObject> OnCardCollision;
        public static void CardCollision(GameObject a, GameObject b) => OnCardCollision?.Invoke(a, b);
        public static event Action<GameObject> OnSoChange;
        public static void SoChange(GameObject g) => OnSoChange?.Invoke(g);
        public static event Action<GameObject> OnCardDefChange;
        public static void CardDefChange(GameObject g) => OnCardDefChange?.Invoke(g);
        public static event Action<GameObject> OnCardAtkChange;
        public static void CardAtkChange(GameObject g) => OnCardAtkChange?.Invoke(g);
        public static event Action<GameObject> OnCardHealthChange;
        public static void CardHealthChange(GameObject g) => OnCardHealthChange?.Invoke(g);
        public static event Action<GameObject> OnCardSickChange;
        public static void CardSickChange(GameObject g) => OnCardSickChange?.Invoke(g);
    }
}