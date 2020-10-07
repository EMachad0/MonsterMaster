using System;
using System.Collections;
using GameAssets.Scripts.CardScripts.TypeBehavior.Controllers;
using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class BattleSystemScript : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        public RandomNumber randomNumber;

        [SerializeField] private MonsterCardController atkCard;
        [SerializeField] private MonsterCardController defCard;
        [SerializeField] private Text atkNumber;
        [SerializeField] private Text defNumber;
        private CanvasGroup _canvas;

        private ServerController _sc;

        private void Awake()
        {
            randomNumber = GameObject.Find("RandomGenerator").GetComponent<RandomNumber>();
            atkCard = transform.GetChild(3).GetComponent<MonsterCardController>();
            defCard = transform.GetChild(4).GetComponent<MonsterCardController>();
            atkNumber = transform.GetChild(5).GetComponent<Text>();
            defNumber = transform.GetChild(6).GetComponent<Text>();
            _canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void StartBattle(GameObject atk, GameObject def)
        {
            var maxAtk = atk.transform.GetChild(1).GetChild(6).GetComponent<Text>().text;
            var maxDef = def.transform.GetChild(1).GetChild(7).GetComponent<Text>().text;
            
            gameObject.SetActive(true);
            _canvas.alpha = 1;

            atkCard.SetCard(atk.GetComponent<MonsterCardController>().cardSo);
            defCard.SetCard(def.GetComponent<MonsterCardController>().cardSo);
            StartCoroutine(Routine());
            StartCoroutine(RandomNumbers(Convert.ToInt32(maxAtk), Convert.ToInt32(maxDef)));
        }
        
        private IEnumerator Routine()
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
            for (var i = 0; i < time; i++)
            {
                randomNumber.GenerateRandomNumber(0, maxAtk + 1);
                atkNumber.text = randomNumber.randomNumber.ToString();
                randomNumber.GenerateRandomNumber(0, maxDef + 1);
                defNumber.text = randomNumber.randomNumber.ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}