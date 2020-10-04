using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop
{
    internal class DragDropHand : DragDropBaseState
    {

        [SerializeField] private bool isOverBoard;
        [SerializeField] private GameObject board;

        public override void OnEnable()
        { 
            base.OnEnable();
            StartBoard();
        }

        [ClientCallback]
        private void StartBoard()
        {
            var cc = Identity.GetComponent<ClientController>();
            board = GameObject.Find(cc.index == 0 ? "P1Board" : "P2Board");
        }

        public override void EndDrag(DragDropFsm fsm)
        {
            if (!isOverBoard) base.EndDrag(fsm);
            else
            {
                Ssc.CmdSetObjectParent(fsm.transform, board.transform, false);
                Ssc.CmdSetVisibility(fsm.gameObject, true);
            }
        }

        public override void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject == board) isOverBoard = true;
        }

        public override void OnCollisionExit2D(Collision2D collision2D)
        {
            if (collision2D.gameObject == board) isOverBoard = false;
        }
    }
}
