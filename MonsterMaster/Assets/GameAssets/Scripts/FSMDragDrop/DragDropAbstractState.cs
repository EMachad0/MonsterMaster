using System;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop
{
    [Serializable]
    public abstract class DragDropAbstractState : ScriptableObject, IDragDropState
    {
        public virtual void BeginDrag(DragDropFsm fsm)
        {
        }

        public virtual void Drag(DragDropFsm fsm)
        {
        }

        public virtual void EndDrag(DragDropFsm fsm)
        {
        }

        public virtual void OnCollisionEnter2D(Collision2D collision2D)
        {
        }

        public virtual void OnCollisionExit2D(Collision2D collision2D)
        {
        }
    }
}