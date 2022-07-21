using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Mp_PhotonConnect : MonoBehaviourPunCallbacks, IInRoomCallbacks, ILobbyCallbacks, IOnEventCallback
{

    public static Mp_PhotonConnect instance;
    [RuntimeInitializeOnLoadMethod]
    public static void LoadAsset()
    {
        Debug.Log("loading...");
        GameObject obj = Resources.Load("Multiplayer/MultiplayerObj") as GameObject;
        obj= Instantiate(obj, Vector3.zero, Quaternion.identity);
        obj.name = "[Multiplayer]";

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        ConnectToMaster();
    }
    #region Connection

    internal void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
        base.OnJoinedLobby();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        base.OnJoinRandomFailed(returnCode, message);
    }

    internal void CreateRoom()
    {
        string RoomName = PhotonNetwork.ServerTimestamp.ToString();
        RoomOptions OPT = new RoomOptions();
        OPT.IsOpen = true;
        OPT.IsVisible = true;
        OPT.CleanupCacheOnLeave = true;
        OPT.MaxPlayers = 19;

        PhotonNetwork.CreateRoom(RoomName, OPT);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player entered>>" + newPlayer);
        base.OnPlayerEnteredRoom(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player Left room>>" + otherPlayer);
        base.OnPlayerLeftRoom(otherPlayer);
    }
    #endregion


    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code > 200)
        {
            return;
        }

    }

}
