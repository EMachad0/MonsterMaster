using GameAssets.Scripts.ClientScripts;
using Mirror;

namespace GameAssets.Scripts
{
    public class MyNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            var player = Instantiate(playerPrefab);
            player.GetComponent<ClientController>().SetIndex(numPlayers);
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}
