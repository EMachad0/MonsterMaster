﻿using GameAssets.Scripts;
using GameAssets.Scripts.ClientScripts;
using Mirror;
using UnityEngine;

namespace MenuAssets.Scripts
{
    [AddComponentMenu("")]
    public class MyRoomController : NetworkRoomManager
    {
        /// <summary>
        /// Called just after GamePlayer object is instantiated and just before it replaces RoomPlayer object.
        /// This is the ideal point to pass any data like player name, credentials, tokens, colors, etc.
        /// into the GamePlayer object as it is about to enter the Online scene.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="roomPlayer"></param>
        /// <param name="gamePlayer"></param>
        /// <returns>true unless some code in here decides it needs to abort the replacement</returns>
        public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
        {
            gamePlayer.GetComponent<Client>().index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
            // var playerController = gamePlayer.GetComponent<Client>();
            // playerController.index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
            return true;
        }

        // public override void OnRoomStopClient()
        // {
        //     // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
        //     // going to the offline scene to avoid collision with the one that lives there.
        //     if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
        //         SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        //
        //     base.OnRoomStopClient();
        // }
        //
        // public override void OnRoomStopServer()
        // {
        //     // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
        //     // going to the offline scene to avoid collision with the one that lives there.
        //     if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
        //         SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        //
        //     base.OnRoomStopServer();
        // }

        /*
            This code below is to demonstrate how to do a Start button that only appears for the Host player
            showStartButton is a local bool that's needed because OnRoomServerPlayersReady is only fired when
            all players are ready, but if a player cancels their ready state there's no callback to set it back to false
            Therefore, allPlayersReady is used in combination with showStartButton to show/hide the Start button correctly.
            Setting showStartButton false when the button is pressed hides it in the game scene since NetworkRoomManager
            is set as DontDestroyOnLoad = true.
        */

        private bool _showStartButton;

        public override void OnRoomServerPlayersReady()
        {
            // calling the base method calls ServerChangeScene as soon as all players are in Ready state.
            #if UNITY_SERVER
            base.OnRoomServerPlayersReady();
            #else
            _showStartButton = true;
            #endif
        }

        public override void OnGUI()
        {
            base.OnGUI();
            if (allPlayersReady && _showStartButton && GUI.Button(new Rect(150, 300, 120, 20), "START GAME"))
            {
                // set to false to hide it in the game scene
                _showStartButton = false;
                ServerChangeScene(GameplayScene);
            }
        }
    }
}
