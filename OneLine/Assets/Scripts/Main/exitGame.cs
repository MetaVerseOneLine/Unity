using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{

    public GameObject checkExit;

    //public GameObject joyStick;
    //public GameObject clickBtn;

    public ControllerManager CM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickExitGame()
    {
        //joyStick.SetActive(false);
        //clickBtn.SetActive(false);

        CM.turnOffJoystick();

        checkExit.SetActive(true);

        //SceneManager.LoadScene("Main");
        //RNConnectManager.Instance.ExixGame();
    }

    public void exit()
    {
        //게임종료
        RNConnectManager.Instance.ExixGame();
    }

    public void leftGame()
    {
        // 취소를 누르면
        checkExit.SetActive(false);
        CM.turnOnJoystick();
    }


}
