using UnityEngine;

namespace MenuAssets
{
    public class UiController : MonoBehaviour
    {
        public void Play()
        {
            MySceneManager.ChangeScene("Game");
        }
    }
}
