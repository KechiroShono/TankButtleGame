using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : Photon.PunBehaviour
{

    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {


        //photonに接続していればPlayerを生成
        GameObject Player = PhotonNetwork.Instantiate(playerPrefab.name, this.transform.position, Quaternion.identity, 0);

    }

    // Update is called once per frame
    void Update()
    {

}
}
