using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highlight : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;

    public Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;
    public GameObject player;
    Color col;
    bool onLitmus;
    bool onFlame;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x < -7.3 && player.transform.position.z < -14)
        {
            GetComponent<Renderer>().material.color = new Color(255, 79, 40);
            onLitmus = true;
        }
        else if ((Math.Abs(GameObject.FindWithTag("Flame").transform.position.x - player.transform.position.x) < 30 &&
            Math.Abs(GameObject.FindWithTag("Flame").transform.position.z - player.transform.position.z) < 2) && player.transform.position.x > 0) {
            GetComponent<Renderer>().material.color = new Color(255, 79, 40);
            onFlame = true;
        }
        else
        {
            GetComponent<Renderer>().material.color = col;
            onLitmus = false;
            onFlame = false;
        }

    }

    public void LapEquipClick() {

        Debug.Log("***LapEquipClick***");
        Debug.Log(onLitmus);
        Debug.Log("***LapEquipClick***");

        ControllerManager.Instance.turnOffJoystick();

        //if (onLitmus == true) SceneManager.LoadScene("Litmus");
        if (onLitmus == true)
            SceneController.Instance.loadSubScene("Litmus");

    }
    public void FlameClick() {

        ControllerManager.Instance.turnOffJoystick();

        //if(onFlame == true) SceneManager.LoadScene("FlameTest");
        if (onFlame == true)
            SceneController.Instance.loadSubScene("FlameTest");

    }
}
