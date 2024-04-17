using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefab;
    void Start()
    {
        if (playerPrefab != null)
        {
            PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-50, 1, 0), Quaternion.identity, 0);
        }
        else
        {
            Debug.LogError("playerPrefab n'est pas défini dans l'inspecteur !");
        }
    }

    public void OnPlayerEnterRoom(Player other)
    {
        print(other.NickName + "s'est connecté !");
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        print(other.NickName + "s'est déconnecté !");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LauncherScene");
    }

    public  void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }
}
