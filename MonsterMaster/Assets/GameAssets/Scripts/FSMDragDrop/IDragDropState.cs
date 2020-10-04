using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop
{
    public interface IDragDropState
    {
        void BeginDrag(DragDropFsm fsm);
        void Drag(DragDropFsm fsm);
        void EndDrag(DragDropFsm fsm);

        void OnCollisionEnter2D(Collision2D collision2D);
        void OnCollisionExit2D(Collision2D collision2D);
    }
}