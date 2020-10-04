using GameAssets.Scripts.FSMDragDrop;
using UnityEngine;
using Mirror;

namespace GameAssets.Scripts
{
    public class HandController : NetworkBehaviour
    {
        private int _lastChildCount;
        
        private void OnTransformChildrenChanged()
        {
            if (transform.childCount > _lastChildCount)
            {
                var nova = transform.GetChild(transform.childCount - 1);
                var fsm = nova.GetComponent<DragDropFsm>();
                nova.gameObject.layer = LayerMask.NameToLayer("CardHand");
                fsm.state = ScriptableObject.CreateInstance<DragDropHand>();
            }

            _lastChildCount = transform.childCount;
        }
    }
}