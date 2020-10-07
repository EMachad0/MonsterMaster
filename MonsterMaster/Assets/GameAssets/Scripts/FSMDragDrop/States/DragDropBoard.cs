using System.Collections.Generic;
using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop.States
{
    internal class DragDropBoard : DragDropBaseState
    {

        private BattleSystem _popup;

        [SerializeField] private List<GameObject> colliders = new List<GameObject>();

        public override void OnEnable()
        {
            base.OnEnable();
            _popup = PopupSpawner.Instance.FindObject("Battle").GetComponent<BattleSystem>();
        }

        public override void EndDrag(DragDropFsm fsm)
        {
            if (colliders.Count != 1) base.EndDrag(fsm);
            else
            {
                var enemy = colliders[0];
                var identity = NetworkClient.connection.identity;
                var sc = identity.GetComponent<ServerController>();
                sc.CmdShowBattle(fsm.gameObject, enemy);
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