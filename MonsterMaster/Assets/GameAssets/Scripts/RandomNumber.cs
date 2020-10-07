using Mirror;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class RandomNumber : NetworkBehaviour
    {
        [SyncVar(hook="NumberChanged")]
        public int randomNumber;
        
        public void NumberChanged(int oldVale, int newValue) {
            randomNumber = newValue;
            print("Random number: " + randomNumber);
        }
   
        public void GenerateRandomNumber(int a, int b) {
            if (isServer) randomNumber = Random.Range(a, b);
        }
    }
}