using System;
using GameAssets.Scripts.CardControllers;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class ServerController : NetworkBehaviour
    {
        private ClientController _cc;
        
        public GameObject monsterPrefab;
        public GameObject spellPrefab;

        private void Awake()
        {
            _cc = GetComponent<ClientController>();
        }

        [Command]
        public void CmdSpawnCard(CardType type, string asset, GameObject parent)
        {
            GameObject c;
            switch (type)
            {
                case CardType.Monster:
                    c = Instantiate(monsterPrefab, parent.transform, false);
                    break;
                case CardType.Spell:
                    c = Instantiate(spellPrefab, parent.transform, false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            NetworkServer.Spawn(c, connectionToClient);
            RpcSetCardAsset(type, c, asset);
            RpcSetObjectParent(c.transform, parent.transform, false);
        }

        [Command]
        public void CmdSetObjectParent(Transform g, Transform parent, bool worldPosStay)
        {
            g.SetParent(parent, worldPosStay);
            RpcSetObjectParent(g, parent, worldPosStay);
        }

        [ClientRpc]
        private void RpcSetCardAsset(CardType type, GameObject card, string asset)
        {
            switch (type)
            {
                case CardType.Monster:
                    var c1 = card.GetComponent<MonsterCardController>();
                    c1.SetCard(Resources.Load<SoMonsterCard>(asset));
                    break;
                case CardType.Spell:
                    var c2 = card.GetComponent<SpellCardController>();
                    c2.SetCard(Resources.Load<SoSpellCard>(asset));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        [ClientRpc]
        private void RpcSetObjectParent(Transform g, Transform parent, bool worldPosStay)
        {
            g.SetParent(parent, worldPosStay);
        }

        [Command]
        public void CmdDestroy(GameObject g)
        {
            NetworkServer.Destroy(g);
        }

        [Command]
        public void CmdEndTurn()
        {
            RpcEndTurn();
        } 
        
        [ClientRpc]
        private void RpcEndTurn()
        {
            TurnSystemFsm.Instance.EndTurn();
        }

        [Command]
        public void CmdSetVisibility(GameObject g, bool visibility)
        {
            RpcSetVisibility(g, visibility);
        }

        [ClientRpc]
        private void RpcSetVisibility(GameObject g, bool visibility)
        {
            var cardFlip = g.GetComponent<CardFlip>();
            if (visibility) cardFlip.Show();
            else cardFlip.Hide();
        }

        [Command]
        public void CmdSpawnDecks()
        {
            RpcSpawnDecks();
            RpcEndTurn();
        }

        [ClientRpc]
        private void RpcSpawnDecks()
        {
            var identity = NetworkClient.connection.identity;
            var localPlayer = identity.GetComponent<ClientController>();
            localPlayer.SpawnDeck();
        }
    }
}