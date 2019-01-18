using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVariables : MonoBehaviour
{

    static public int currentHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        VariableReset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void VariableReset()
    {
        currentHP = 100;
    }
}
