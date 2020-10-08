using GameAssets.Scripts.FSMCard;
using UnityEngine;
using Mirror;

namespace GameAssets.Scripts
{
    public class Hand : NetworkBehaviour
    {
        private int _lastChildCount;
        
        private void OnTransformChildrenChanged()
        {
            if (transform.childCount > _lastChildCount)
            {
                var nova = transform.GetChild(transform.childCount - 1);
            }

            _lastChildCount = transform.childCount;
        }
    }
}