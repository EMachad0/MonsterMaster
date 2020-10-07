using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop.States
{
    public class DragDropBaseState : DragDropAbstractState
    {
        protected NetworkIdentity Identity;
        protected ServerController Ssc;
        
        private GameObject _canvas;

        private GameObject _startParent;
        private Vector2 _startPos;

        public virtual void OnEnable()
        {
            StartIdentity();
            _canvas = GameObject.Find("Canvas");
        }

        [ClientCallback]
        private void StartIdentity()
        {
            Identity = NetworkClient.connection.identity;
            Ssc = Identity.GetComponent<ServerController>();
        }

        public override void BeginDrag(DragDropFsm fsm)
        {
            var transform = fsm.transform;
            
            _startParent = transform.parent.gameObject;
            _startPos = transform.position;
            Ssc.CmdSetObjectParent(transform, _canvas.transform, true);
        }

        public override void Drag(DragDropFsm fsm)
        {
            var transform = fsm.transform;
            
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            transform.position = mousePosition;
        }

        public override void EndDrag(DragDropFsm fsm)
        {
            var transform = fsm.transform;
            
            transform.position = _startPos;
            Ssc.CmdSetObjectParent(transform, _startParent.transform, true);
        }
    }
}