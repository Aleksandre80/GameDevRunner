using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class MyLauncher : MonoBehaviourPunCallbacks
{
    public Button btn;
    public TMP_Text feedbackText;

    private byte maxPlayersPerRoom = 4;

    bool isConnecting;
    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect()
    {
        feedbackText.text = "";

        isConnecting = true;

        btn.interactable = false;

        /*controlPanel.SetActive(false);

        if(loaderAnime != null)
        {
            loaderAnime.StartLoaderAnimation();
        }*/

        if (PhotonNetwork.IsConnected)
        {
            LogFeedBack("Joinning Romm...");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            LogFeedBack("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = this.gameVersion;
        }
    }

    void LogFeedBack(string message)
    {
        if(feedbackText == null)
        {
            return;
        }

        feedbackText.text = System.Environment.NewLine + message;
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            LogFeedBack("OnConnectedToMaster Try to join the room");
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        isConnecting = false;
        btn.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("1");
            PhotonNetwork.LoadLevel("Runner");
        }
    }



}
