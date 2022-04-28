using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;

    public GameObject joystick;
    public GameObject clickBtn;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        joystick.SetActive(true);
        clickBtn.SetActive(true);
    }

    public void turnOnJoystick()
    {
        joystick.SetActive(true);
        clickBtn.SetActive(true);
    }

    public void turnOffJoystick()
    {
        joystick.SetActive(false);
        clickBtn.SetActive(false);
    }


}
