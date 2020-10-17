using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.FSMCard.States
{
    internal class HandState : DraggableState
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
            var cc = Server.LocalPlayer.GetComponent<Client>();
            board = GameObject.Find(cc.index == 0 ? "P1Board" : "P2Board");
        }

        public override void StartState(CardFsm fsm)
        {
            base.StartState(fsm);
            fsm.gameObject.layer = LayerMask.NameToLayer("CardHand");
        }

        public override void EndDrag(CardFsm fsm)
        {
            if (!isOverBoard) base.EndDrag(fsm);
            else
            {
                var cardController = Server.LocalPlayer.GetComponent<CardController>();
                cardController.CmdCardParent(fsm.gameObject, board, false);
                cardController.CmdEndState(fsm.gameObject);
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

        public override void EndState(CardFsm fsm)
        {
            fsm.ChangeState(CreateInstance<BoardState>());
        }
    }
}
