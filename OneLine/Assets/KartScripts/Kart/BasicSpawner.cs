using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class BasicSpawner : NetworkBehaviour, INetworkRunnerCallbacks
{

    private NetworkRunner _runner;

    [SerializeField] private NetworkPrefabRef[] _playerPrefab;
    private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();

    int PlayerPrefabIdx;

    public string RoomName;


    public void SetPlayerPrefab(int index)
    {
        PlayerPrefabIdx = index;
    }

    //private void OnGUI()
    //{
    //    // 프리펩 테스트 임시 주
    //    if (_runner == null)
    //    {
    //        if (GUI.Button(new Rect(0, 0, 200, 40), "Shared"))
    //        {
    //            //StartGame(GameMode.Host);
    //            StartGame(GameMode.Shared);
    //        }
    //        //if (GUI.Button(new Rect(0, 40, 200, 40), "Join"))
    //        //{
    //        //    StartGame(GameMode.Client);

    //        //}
    //    }
    //}

    // 네트워크에서 받을 스타트 함수
    [Rpc(sources: RpcSources.All, targets: RpcTargets.All)]
    public void RPC_StartGame()
    {
        Debug.Log("RPC통신으로 시작함수 실행");
        KartGameManager.instance.GameStart();
    }

    public async void StartGame(GameMode mode)
    {
        // Create the Fusion runner and let it know that we will be providing user input
        _runner = gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;

        // Start or join (depends on gamemode) a session with a specific name
        Debug.Log("@@@@@@@@@");
        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = KartGameManager.instance.roomCode,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneObjectProvider = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            PlayerCount = 5
        }) ;
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (KartGameManager.instance.player == null)
        {
            Debug.Log("OnPlayerJoined");
            // Create a unique position for the player
            //Debug.Log($"player.RawEncoded : {player.RawEncoded}");
            //Debug.Log($"runner.Config.Simulation.DefaultPlayers : {runner.Config.Simulation.DefaultPlayers}");
            Vector3 spawnPosition = new Vector3(-5.43f + (player.RawEncoded % runner.Config.Simulation.DefaultPlayers) * 1.81f, 1, 0);

            //Vector3 spawnPosition = new Vector3(0, 1, 0);
            NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab[PlayerPrefabIdx], spawnPosition, Quaternion.identity, player);

            // Keep track of the player avatars so we can remove it when they disconnect
            _spawnedCharacters.Add(player, networkPlayerObject);
        }
        //else
        //{
        //    Debug.Log("OnPlayerJoined");
        //    // Create a unique position for the player
        //    Vector3 spawnPosition = new Vector3((player.RawEncoded % runner.Config.Simulation.DefaultPlayers) * 3, 1, 0);
        //    NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
        //    // Keep track of the player avatars so we can remove it when they disconnect
        //    _spawnedCharacters.Add(player, networkPlayerObject);
        //}

    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        // Find and remove the players avatar
        if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            _spawnedCharacters.Remove(player);
        }
    }

    public void OnConnectedToServer(NetworkRunner runner) {
        Debug.Log("help@@@@@@@@");
    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }

}
