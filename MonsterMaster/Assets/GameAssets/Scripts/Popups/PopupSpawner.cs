using System.Linq;
using Mirror;
using UnityEngine;

namespace GameAssets.Scripts.Popups
{
    public class PopupSpawner : NetworkBehaviour
    {
        public static PopupSpawner Instance;

        public override void OnStartLocalPlayer()
        {
            Instance = this;
        }

        public GameObject FindObject(string name)
        {
            var trs= GetComponentsInChildren<Transform>(true);
            return (from g in trs where g.name == name select g.gameObject).FirstOrDefault();
        }
    }
}