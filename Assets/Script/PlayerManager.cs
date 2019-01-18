using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Photon.PunBehaviour, IPunObservable
{
    public GameObject PlayerUIPrefab;

    public int HP = 100;

    public static GameObject LocalPlayerInstance;

    GameObject _uiGo;





    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.isMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
    }

    void Start()
    {
        if (PlayerUIPrefab != null)
        {
            _uiGo = Instantiate(PlayerUIPrefab) as GameObject;
            _uiGo.SendMessage("Settarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {
            Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUIPrefab reference on player Prefab.", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!photonView.isMine) //このオブジェクトがLocalでなければ実行しない
        {
            return;
        }
        //LocalVariablesを参照し、現在のHPを更新
        HP = LocalVariables.currentHP;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.HP);
            //stream.SendNext(this.ChatText);
        }
        else
        {
            this.HP = (int)stream.ReceiveNext();
            //this.ChatText = (string)stream.ReceiveNext();
        }
    }


}
