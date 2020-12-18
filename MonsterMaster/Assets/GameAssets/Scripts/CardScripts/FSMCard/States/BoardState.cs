using System.Collections.Generic;
using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.CardScripts.FSMCard.States
{
    internal class BoardState : DraggableState
    {
        [SerializeField] private List<GameObject> colliders = new List<GameObject>();

        public override void StartState(CardFsm fsm)
        {
            base.StartState(fsm);
            fsm.gameObject.layer = LayerMask.NameToLayer("CardBoard");
            fsm.GetComponent<CardFlip>().Show();
        }

        public override void EndDrag(CardFsm fsm)
        {
            if (colliders.Count != 1) base.EndDrag(fsm);
            else
            {
                var enemy = colliders[0];
                var controller = Server.LocalPlayer.GetComponent<CardController>();
                controller.CmdCardCollision(fsm.gameObject, enemy);
                base.EndDrag(fsm);
            }
        }
        
        public override void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (!collision2D.gameObject.GetComponent<NetworkIdentity>().hasAuthority) colliders.Add(collision2D.gameObject);
        }

        public override void OnCollisionExit2D(Collision2D collision2D)
        {
            if (!collision2D.gameObject.GetComponent<NetworkIdentity>().hasAuthority) colliders.Remove(collision2D.gameObject);
        }
    }
}