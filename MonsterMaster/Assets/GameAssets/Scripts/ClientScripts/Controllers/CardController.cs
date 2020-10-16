using System;
using GameAssets.Scripts.CardScripts;
using GameAssets.Scripts.CardScripts.FSMCard;
using GameAssets.Scripts.CardScripts.TypeBehavior.Controllers;
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
            AbstractAssetController assetController;
            switch (type)
            {
                case CardType.Monster:
                    c = Instantiate(monsterPrefab);
                    assetController = c.GetComponent<MonsterAssetController>();
                    break;
                case CardType.Spell:
                    c = Instantiate(spellPrefab);
                    assetController = c.GetComponent<SpellAssetController>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            c.GetComponent<CardParent>().parent = parent;
            NetworkServer.Spawn(c, connectionToClient);
            assetController.asset = asset;
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
        public void CmdHeal(GameObject card, int v)
        {
            var c = card.GetComponent<MonsterAssetController>();
            c.curHealth = Math.Min(c.maxHealth, c.curHealth + v);
        }
        
        [Command]
        public void CmdDamage(GameObject card, int v)
        {
            var c = card.GetComponent<MonsterAssetController>();
            c.curHealth = Math.Max(0, c.curHealth - v);
        }
        
        [Command]
        public void CmdSetHealth(GameObject card, int v)
        {
            card.GetComponent<MonsterAssetController>().curHealth = v;
        }
        
        [Command]
        public void CmdSetAttack(GameObject card, int v)
        {
            card.GetComponent<MonsterAssetController>().attack = v;
        }
        
        [Command]
        public void CmdSetDefense(GameObject card, int v)
        {
            card.GetComponent<MonsterAssetController>().defense = v;
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
        
        [Command]
        public void CmdCardCollision(GameObject a, GameObject b) => RpcCardCollision(a, b);

        [ClientRpc]
        private void RpcCardCollision(GameObject a, GameObject b) => CardEvents.CardCollision(a, b);
    }
}