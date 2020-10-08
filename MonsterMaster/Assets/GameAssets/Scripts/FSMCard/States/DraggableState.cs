using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using UnityEngine;

namespace GameAssets.Scripts.FSMCard.States
{
    public class DraggableState : CardAbstractState
    {
        private GameObject _canvas;

        private GameObject _startParent;
        private Vector2 _startPos;

        public virtual void OnEnable()
        {
            _canvas = GameObject.Find("Canvas");
        }

        public override void BeginDrag(CardFsm fsm)
        {
            var transform = fsm.transform;
            
            _startParent = transform.parent.gameObject;
            _startPos = transform.position;
            Server.LocalPlayer.GetComponent<CardController>().CmdCardParent(fsm.gameObject, _canvas, true);
        }

        public override void Drag(CardFsm fsm)
        {
            var transform = fsm.transform;
            
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            transform.position = mousePosition;
        }

        public override void EndDrag(CardFsm fsm)
        {
            var transform = fsm.transform;

            Server.LocalPlayer.GetComponent<CardController>().CmdCardParent(fsm.gameObject, _startParent, true);
            transform.position = _startPos;
        }
    }
}