using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    


	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        Destroy(this.gameObject, 4.0f);
    }

    private void OnCollisionEnter(Collision col)
    {

    }

}
