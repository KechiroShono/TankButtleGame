using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogInManagerScript : Photon.PunBehaviour
{
    #region Public変数定義
    //Public変数の定義は変数の定義はここで
    #endregion

    #region Private変数
    //Private変数の定義はここで
    string _gameVersion = "test";//gameのバージョン。仕様が異なるバージョンとなったときはエラーが発生する
    #endregion

    public void Connect()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
            Debug.Log("Photonに接続しました");
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed (object[] codeAndMsg)
    {
        Debug.Log("ルームの入室に失敗しました"); 
        //テストルームという名の部屋を作成して、部屋に入る
        PhotonNetwork.CreateRoom("TestRoom");
    }
    //部屋に入ったときに呼ばれる関数
    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました");
        //stage1をロード
        PhotonNetwork.LoadLevel("SelectScene");
    }




}

