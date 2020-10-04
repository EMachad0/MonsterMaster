using GameAssets.Scripts.FSMDragDrop;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class BoardController : NetworkBehaviour
    {
        private int _lastChildCount;

        private void OnTransformChildrenChanged()
        {
            if (transform.childCount > _lastChildCount)
            {
                var nova = transform.GetChild(transform.childCount - 1);
                var fsm = nova.GetComponent<DragDropFsm>();
                nova.GetComponent<CardFlip>().Show();
                nova.gameObject.layer = LayerMask.NameToLayer("CardBoard");
                fsm.state = ScriptableObject.CreateInstance<DragDropBoard>();
            }

            _lastChildCount = transform.childCount;
        }
    }
}