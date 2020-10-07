using GameAssets.Scripts.CardScripts;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts.ClientScripts
{
    public class ClientController : NetworkBehaviour
    {
        [SyncVar]
        public int index = -1;

        private ServerController _sc;
        private GameObject _canvas;

        private void Awake()
        {
            _sc = GetComponent<ServerController>();
            _canvas = GameObject.Find("Canvas");
        }

        private void Start()
        {
            name = "P" + index;
        }
        
        public override void OnStartLocalPlayer()
        {
            switch (index)
            {
                case 0:
                    P1Config();
                    break;
                case 1:
                    P2Config();
                    break;
                default:
                    Debug.Log("Player with invalid index");
                    break;
            }
        }

        public void SpawnDeck()
        {
            if (!isLocalPlayer) return;
            
            var deck = GameObject.Find(index == 0 ? "P1Deck" : "P2Deck");
            var grid = deck.transform.GetChild(0).gameObject;

            var monsters = new[] {"Rat", "Hydra"};
            var spells = new[] {"Antidote"};
            for (var i = 0; i < 3; i++)
            {
                if (Random.value <= monsters.Length / (float) (monsters.Length + spells.Length))
                {
                    _sc.CmdSpawnCard(CardType.Monster, monsters[Random.Range(0, monsters.Length)], grid);
                }
                else
                {
                    _sc.CmdSpawnCard(CardType.Spell, spells[Random.Range(0, spells.Length)], grid);
                }
            }
        }

        private void P1Config()
        {
        }
        
        private void P2Config()
        {
            _canvas.transform.Rotate(new Vector3(0, 0, 180));
            _sc.CmdSpawnDecks();
        }
        
        public void SetIndex(int v)
        {
            index = v;
            name = "P" + index;
        }
    }
}