using System;
using System.Collections;
using GameAssets.Scripts.CardScripts.TypeBehavior.Controllers;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.Popups
{
    public class BattleSystem : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        public float randomTime;

        [SerializeField] private MonsterAssetController atkCard;
        [SerializeField] private MonsterAssetController defCard;
        [SerializeField] private Text atkNumber;
        [SerializeField] private Text defNumber;
        
        private CanvasGroup _canvas;

        private void Awake()
        {
            atkCard = transform.GetChild(3).GetComponent<MonsterAssetController>();
            defCard = transform.GetChild(4).GetComponent<MonsterAssetController>();
            atkNumber = transform.GetChild(5).GetComponent<Text>();
            defNumber = transform.GetChild(6).GetComponent<Text>();
            _canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(ShowRoutine());
            // gameObject.SetActive(false);
        }

        public void StartBattle(GameObject atk, GameObject def)
        {
            var maxAtk = atk.transform.GetChild(1).GetChild(7).GetComponent<Text>().text;
            var maxDef = def.transform.GetChild(1).GetChild(6).GetComponent<Text>().text;
            
            gameObject.SetActive(true);
            _canvas.alpha = 1;

            if (isServer)
            {
                atkCard.asset = atk.GetComponent<MonsterAssetController>().asset;
                defCard.asset = def.GetComponent<MonsterAssetController>().asset;
            }
            
            StartCoroutine(ShowRoutine());
            if (isServer) StartCoroutine(RandomNumbers(Convert.ToInt32(maxAtk), Convert.ToInt32(maxDef)));
        }
        
        private IEnumerator ShowRoutine()
        {
            yield return new WaitForSeconds(time);
            
            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= Time.deltaTime / fadeoutTime;
                yield return null;
            }
            gameObject.SetActive(false);
            _canvas.alpha = 0;
        }

        private IEnumerator RandomNumbers(int maxAtk, int maxDef)
        {
            for (var i = 0f; i < time; i += randomTime)
            {
                atkNumber.GetComponent<RandomNumber>().Generate(0, maxAtk + 1);
                defNumber.GetComponent<RandomNumber>().Generate(0, maxDef + 1);
                yield return new WaitForSeconds(randomTime);
            }
        }
    }
}