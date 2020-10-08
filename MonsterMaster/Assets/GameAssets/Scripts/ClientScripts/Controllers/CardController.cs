using System;
using GameAssets.Scripts.CardScripts;
using GameAssets.Scripts.CardScripts.TypeBehavior.Controllers;
using GameAssets.Scripts.FSMCard;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class CardController : NetworkBehaviour
    {
        public GameObject monsterPrefab;
        public GameObject spellPrefab;

        [Command]
        public void CmdSpawnCard(CardType type, string asset, GameObject parent)
        {
            GameObject c;
            switch (type)
            {
                case CardType.Monster:
                    c = Instantiate(monsterPrefab);
                    c.GetComponent<MonsterAssetController>().asset = asset;
                    break;
                case CardType.Spell:
                    c = Instantiate(spellPrefab);
                    c.GetComponent<SpellAssetController>().asset = asset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            c.GetComponent<CardParent>().parent = parent;
            NetworkServer.Spawn(c, connectionToClient);
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
        public void CmdCardParent(GameObject card, GameObject parent, bool worldPosStays)
        {
            var cardParent = card.GetComponent<CardParent>();
            cardParent.worldPosStay = worldPosStays;
            cardParent.parent = parent;
        }
        
        [Command]
        public void CmdCardAsset(GameObject card, CardType type, string asset)
        {
            switch (type)
            {
                case CardType.Monster:
                    card.GetComponent<MonsterAssetController>().asset = asset;
                    break;
                case CardType.Spell:
                    card.GetComponent<SpellAssetController>().asset = asset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        [Command]
        public void CmdEndState(GameObject card)
        {
            RpcEndState(card);
        }

        [ClientRpc]
        private void RpcEndState(GameObject card)
        {
            card.GetComponent<CardFsm>().EndState();
        }
    }
}