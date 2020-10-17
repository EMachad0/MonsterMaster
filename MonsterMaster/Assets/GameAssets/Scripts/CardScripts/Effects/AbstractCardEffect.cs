using UnityEngine;

namespace GameAssets.Scripts.CardScripts.Effects
{
    public abstract class AbstractCardEffect : ScriptableObject
    {
        public virtual void OnTurnStart() {}

        public virtual void OnTurnEnd() {}

        public virtual bool CanDrag() => true;
    }
}