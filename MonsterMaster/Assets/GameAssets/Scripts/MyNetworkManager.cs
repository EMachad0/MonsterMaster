using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class MyNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            var player = Instantiate(playerPrefab);
            player.GetComponent<Client>().index = numPlayers;
            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            Server.LocalPlayer.GetComponent<Server>().CmdDisconnect();
        }
    }
}
