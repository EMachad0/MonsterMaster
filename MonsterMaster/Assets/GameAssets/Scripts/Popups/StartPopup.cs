using System.Collections;
using GameAssets.Scripts.ClientScripts;
using GameAssets.Scripts.ClientScripts.Controllers;
using GameAssets.Scripts.FSMTurnSystem;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.Popups
{
    public class StartPopup : NetworkBehaviour
    {
        public float time;
        public float fadeoutTime;
        public string trigger;

        private CanvasGroup _canvas;
        private Text _text;
        [SyncVar(hook = nameof(SetText))] public string text;

        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
            _text = GetComponentInChildren<Text>();
        }
        
        private void Start()
        {
            StartCoroutine(ShowRoutine());
            TurnSystemFsm.OnStartTurn += OnStartTurn;
        }

        private void OnDestroy()
        {
            TurnSystemFsm.OnStartTurn -= OnStartTurn;
        }

        [ServerCallback]
        private void OnStartTurn()
        {
            if (!isServer) return;
            if (isClient) text = "Player " + (TurnSystemFsm.Instance.IsMyTurn() ? "1" : "2") + "'s turn!";
            Server.LocalPlayer.GetComponent<PopupController>().CmdShowPopup(gameObject);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvas.alpha = 1;
            StartCoroutine(ShowRoutine());
        }

        private IEnumerator ShowRoutine()
        {
            yield return new WaitForSeconds(time);

            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= Time.deltaTime / fadeoutTime;
                yield return null;
            }
            // gameObject.SetActive(false);
        }

        private void SetText(string oldValue, string newValue) => _text.text = newValue;
    }
}