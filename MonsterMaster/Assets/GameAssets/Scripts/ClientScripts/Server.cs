using GameAssets.Scripts.ClientScripts.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts
{
    public class Server : NetworkBehaviour
    {
        public static GameObject LocalPlayer;
        public static GameObject ServerPlayer;
        public static GameObject Player1;
        public static GameObject Player2;

        public override void OnStartLocalPlayer()
        {
            if (isServer) ServerPlayer = gameObject;
            LocalPlayer = gameObject;
            
            var index = gameObject.GetComponent<Client>().index;
            switch (index)
            {
                case 0:
                    Player1 = gameObject;
                    break;
                case 1:
                    Player2 = gameObject;
                    break;
                default:
                    Debug.LogError("Player with invalid index");
                    break;
            }
        }

        public override void OnStartClient()
        {
            if (!isServer || NetworkServer.connections.Count != 2) return;
            LocalPlayer.GetComponent<TurnController>().CmdEndTurn();
        }

        [Command]
        public void CmdDisconnect() => NetworkServer.Shutdown();

        [Command]
        public void CmdDestroy(GameObject g)
        {
            NetworkServer.Destroy(g);
        }
    }
}