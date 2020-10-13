using System.Collections;
using GameAssets.Scripts.CardScripts.TypeBehavior.Controllers;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.Popups
{
    public class BattleSystem : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        public float randomTime;

        [SerializeField] private MonsterAssetController atkCard;
        [SerializeField] private MonsterAssetController defCard;
        [SerializeField] private RandomNumber atkNumber;
        [SerializeField] private RandomNumber defNumber;
        
        private CanvasGroup _canvas;

        private void Awake()
        {
            atkCard = transform.GetChild(3).GetComponent<MonsterAssetController>();
            defCard = transform.GetChild(4).GetComponent<MonsterAssetController>();
            atkNumber = transform.GetChild(5).GetComponent<RandomNumber>();
            defNumber = transform.GetChild(6).GetComponent<RandomNumber>();
            _canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(ShowRoutine());
            // gameObject.SetActive(false);
        }

        public void StartBattle(GameObject atk, GameObject def)
        {
            if (atk is null || def is null) return;
            
            gameObject.SetActive(true);
            _canvas.alpha = 1;
            
            StartCoroutine(ShowRoutine());

            if (!isServer) return;
            var atkController = atk.GetComponent<MonsterAssetController>();
            var defController = def.GetComponent<MonsterAssetController>();
            
            atkCard.asset = atkController.asset;
            atkCard.curHealth = atkController.curHealth;
            defCard.asset = defController.asset;
            defCard.curHealth = defController.curHealth;

            StartCoroutine(RandomNumbers(atkController.attack, defController.defense));
            StartCoroutine(ResolveBattle(atk, def));
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
                atkNumber.Generate(0, maxAtk + 1);
                defNumber.Generate(0, maxDef + 1);
                yield return new WaitForSeconds(randomTime);
            }
        }

        private IEnumerator ResolveBattle(GameObject atk, GameObject def)
        {
            yield return new WaitForSeconds(time);

            var damage = atkNumber.randomNumber - defNumber.randomNumber;
            if (damage > 0) def.GetComponent<MonsterAssetController>().curHealth -= damage;
            else atk.GetComponent<MonsterAssetController>().curHealth += damage;
        }
    }
}