using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    public class Rat : MonsterCardSo
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            background = new Color(0.26f, 0.57f, 0.26f);
            health = 2;
            atk = 2;
            def = 1;
            cardEffectText = "Poison enemy on hit";
        }
    }
}