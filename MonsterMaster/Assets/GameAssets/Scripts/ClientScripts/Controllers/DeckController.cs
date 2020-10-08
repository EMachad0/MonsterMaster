using GameAssets.Scripts.CardScripts;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class DeckController : NetworkBehaviour
    {
        private CardController _cardController;

        private void Awake()
        {
            _cardController = GetComponent<CardController>();
        }

        public override void OnStartLocalPlayer()
        {
            CmdSpawnDecks();
        }

        [Command]
        private void CmdSpawnDecks()
        {
            RpcSpawnDecks();
        }

        [ClientRpc]
        private void RpcSpawnDecks()
        {
            if (!isLocalPlayer) return;
            
            var deck = GameObject.Find(GetComponent<Client>().index == 0 ? "P1Deck" : "P2Deck");
            var grid = deck.transform.GetChild(0).gameObject;

            var monsters = new[] {"Rat", "Hydra"};
            var spells = new[] {"Antidote"};
            for (var i = 0; i < 3; i++)
            {
                if (Random.value <= monsters.Length / (float) (monsters.Length + spells.Length))
                {
                    _cardController.CmdSpawnCard(CardType.Monster, monsters[Random.Range(0, monsters.Length)], grid);
                }
                else
                {
                    _cardController.CmdSpawnCard(CardType.Spell, spells[Random.Range(0, spells.Length)], grid);
                }
            }
        }
    }
}