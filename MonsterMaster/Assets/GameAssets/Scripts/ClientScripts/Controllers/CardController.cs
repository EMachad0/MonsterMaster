using System;
using GameAssets.Scripts.CardScripts;
using GameAssets.Scripts.CardScripts.FSMCard;
using GameAssets.Scripts.CardScripts.TypeBehavior;
using GameAssets.Scripts.CardScripts.TypeBehavior.AssetLoader;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.ClientScripts.Controllers
{
    public class CardController : NetworkBehaviour
    {
        public GameObject monsterPrefab;
        public GameObject spellPrefab;

        [Command]
        public void CmdSpawnCard(CardType type, string soName, GameObject parent)
        {
            GameObject c;
            switch (type)
            {
                case CardType.Monster:
                    c = Instantiate(monsterPrefab);
                    break;
                case CardType.Spell:
                    c = Instantiate(spellPrefab);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            NetworkServer.Spawn(c, connectionToClient);
            c.GetComponent<CardParent>().parent = parent;
            c.GetComponent<SoLoader>().so = soName;
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
        public void CmdCardSoChange(GameObject card, string so) => card.GetComponent<SoLoader>().so = so;

        [ClientRpc, ServerCallback]
        public void RpcCardSoChange(GameObject card) => CardEvents.SoChange(card);

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