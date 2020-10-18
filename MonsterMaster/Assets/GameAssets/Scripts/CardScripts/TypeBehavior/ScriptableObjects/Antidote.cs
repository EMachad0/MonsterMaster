using GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects.Abstract;

namespace GameAssets.Scripts.CardScripts.TypeBehavior.ScriptableObjects
{
    public class Antidote : SpellCardSo
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            cardEffectText = "Cure poison";
        }
    }
}