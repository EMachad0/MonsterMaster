using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts
{
    public class CardParent : NetworkBehaviour
    {
        [SyncVar(hook = nameof(ParentHook))]
        public GameObject parent;

        [SyncVar]
        public bool worldPosStay;

        private void ParentHook(GameObject oldValue, GameObject newValue)
        {
            transform.SetParent(newValue.transform, worldPosStay);
        }
    }
}