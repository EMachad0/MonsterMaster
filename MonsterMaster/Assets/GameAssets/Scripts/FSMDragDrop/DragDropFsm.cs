using System;
using GameAssets.Scripts.FSMDragDrop.States;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.FSMDragDrop
{
    [Serializable]
    public class DragDropFsm : NetworkBehaviour
    {
        public DragDropAbstractState state;

        private TurnSystemFsm _ts;

        private void Start()
        {
            _ts = TurnSystemFsm.Instance;
        }

        public void BeginDrag()
        {
            if (!hasAuthority || !_ts.IsMyTurn()) return;
            state.BeginDrag(this);
        }

        public void Drag()
        {
            if (!hasAuthority || !_ts.IsMyTurn()) return;
            state.Drag(this);
        }

        public void EndDrag()
        {
            if (!hasAuthority || !_ts.IsMyTurn()) return;
            state.EndDrag(this);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            state.OnCollisionEnter2D(collision);
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            state.OnCollisionExit2D(collision);
        }
    }
}