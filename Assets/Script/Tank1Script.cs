using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1Script : MonoBehaviour {
    //オンライン化に必要なコンポーネントを設定
    public PhotonView myPV;
    public PhotonTransformView myPTV;

    public float moveSpeed = 3.0f;
    public Joystick joystick;


    void Start ()
    {

    }
	

	void Update () 
    {
        if (myPV.isMine)
        {
            return;
        }

        Move();
        //スムーズな同期の為にPhotonTransformViewに速度値を渡す


    }

    //移動に関する関数
    void Move()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
        }


    }
    //当たり判定
    private void OnCollisionEnter(Collision col)
    {

    }

}




