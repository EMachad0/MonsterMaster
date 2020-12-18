using Mirror;

namespace GameAssets.Scripts
{
    public class Board : NetworkBehaviour
    {
        private int _lastChildCount;

        private void OnTransformChildrenChanged()
        {
            if (transform.childCount > _lastChildCount)
            {
                var nova = transform.GetChild(transform.childCount - 1);
                // do something with new card
            }
            _lastChildCount = transform.childCount;
        }
    }
}