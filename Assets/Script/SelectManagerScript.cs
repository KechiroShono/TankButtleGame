using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManagerScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.connected)
        {
            SceneManager.LoadScene("LogInScene");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Stage1Button()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2Button()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3Button()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage4Button()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void Stage5Button()
    {
        SceneManager.LoadScene("Stage5");
    }

    public void RandomButton()
    {
        SceneManager.LoadScene("Stages[]");
    }
}
