using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMain : MonoBehaviour
{
    public void BackMainn()
    {
        //SceneManager.LoadScene("MainScene");
        SceneController.Instance.loadSubScene("back");

    }

}
