using System.Collections;
using GameAssets.Scripts.CardScripts;
using GameAssets.Scripts.CardScripts.TypeBehavior;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.Popups
{
    public class BattleSystem : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        public float randomTime;

        [SerializeField] private GameObject atkCard;
        [SerializeField] private GameObject defCard;
        [SerializeField] private RandomNumber atkNumber;
        [SerializeField] private RandomNumber defNumber;
        
        private CanvasGroup _canvas;

        private void Awake()
        {
            atkCard = transform.GetChild(3).gameObject;
            defCard = transform.GetChild(4).gameObject;
            atkNumber = transform.GetChild(5).GetComponent<RandomNumber>();
            defNumber = transform.GetChild(6).GetComponent<RandomNumber>();
            _canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(ShowRoutine());
            // gameObject.SetActive(false);

            CardEvents.OnCardCollision += StartBattle;
        }

        private void OnDestroy()
        {
            CardEvents.OnCardCollision -= StartBattle;
        }

        public void StartBattle(GameObject atk, GameObject def)
        {
            if (atk is null || def is null) return;
            
            gameObject.SetActive(true);
            _canvas.alpha = 1;
            
            StartCoroutine(ShowRoutine());
            
            if (!isServer) return;
            atkCard.GetComponent<SoLoader>().soName = atk.GetComponent<SoLoader>().soName;
            defCard.GetComponent<SoLoader>().soName = def.GetComponent<SoLoader>().soName;
            
            StartCoroutine(RandomNumbers(atk.GetComponent<StatsLoader>().atk, def.GetComponent<StatsLoader>().def));
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
        
            var damage = atkNumber.value - defNumber.value;
            if (damage > 0)
            {
                defCard.GetComponent<StatsLoader>().health -= damage;
                def.GetComponent<StatsLoader>().health -= damage;
            }
            else
            {
                atkCard.GetComponent<StatsLoader>().health += damage;
                atk.GetComponent<StatsLoader>().health += damage;
            }
        }
    }
}