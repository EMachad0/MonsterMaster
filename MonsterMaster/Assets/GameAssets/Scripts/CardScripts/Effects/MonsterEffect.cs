using UnityEngine;

namespace GameAssets.Scripts.CardScripts.Effects
{
    public abstract class MonsterEffect : AbstractCardEffect
    {
        [SerializeField] protected int atkPerTurn = 1;
        [SerializeField] protected int atkCount;

        public virtual void OnAttack() => atkCount++;

        public override void OnTurnStart() => atkCount = 0;

        public override bool CanDrag() => atkCount < atkPerTurn;
    }
}