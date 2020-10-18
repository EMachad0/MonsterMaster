using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    public class Hydra : MonsterCardSo
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            background = new Color(0.36f, 0.46f, 0.57f);
            maxHealth = 6;
            health = 6;
            atk = 6;
            def = 5;
            cardEffectText = "Attack twice";
        }
    }
}