using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop
{
    internal class DragDropBoard : DragDropBaseState
    {

        [SerializeField] private List<GameObject> colliders = new List<GameObject>();
        
        public override void EndDrag(DragDropFsm fsm)
        {
            if (colliders.Count != 1) base.EndDrag(fsm);
            else
            {
                var enemy = colliders[0];
                Debug.Log(fsm + " vs " + enemy);
                Ssc.CmdDestroy(enemy);
                Ssc.CmdDestroy(fsm.gameObject);
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