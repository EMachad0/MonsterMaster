using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EditorScripts
{
    public class RoomLogger : MonoBehaviour
    {
        [AddComponentMenu("")]
        public class NetworkRoomPlayerExt : NetworkRoomPlayer
        {
            private static readonly ILogger Logger = LogFactory.GetLogger(typeof(NetworkRoomPlayerExt));

            public override void OnStartClient()
            {
                if (Logger.LogEnabled()) Logger.LogFormat(LogType.Log, "OnStartClient {0}", SceneManager.GetActiveScene().path);
                base.OnStartClient();
            }

            public override void OnClientEnterRoom()
            {
                if (Logger.LogEnabled()) Logger.LogFormat(LogType.Log, "OnClientEnterRoom {0}", SceneManager.GetActiveScene().path);
            }

            public override void OnClientExitRoom()
            {
                if (Logger.LogEnabled()) Logger.LogFormat(LogType.Log, "OnClientExitRoom {0}", SceneManager.GetActiveScene().path);
            }

            public override void ReadyStateChanged(bool _, bool newReadyState)
            {
                if (Logger.LogEnabled()) Logger.LogFormat(LogType.Log, "ReadyStateChanged {0}", newReadyState);
            }
        }
    }
}
