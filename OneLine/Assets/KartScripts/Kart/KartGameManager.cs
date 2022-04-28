using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Fusion;
using System;
using UnityEngine.AddressableAssets;

public class KartGameManager : MonoBehaviour
{
    public static KartGameManager instance;

    [Header("Player")]
    public Car player;

    public float baseSpeed;
    public int lap;
    public bool check;

    [Header("GameObj")]
    public Car[] car;
    public Transform[] target;
    public Controller controllPad;
    public Transform cam;

    [Header("Menu")]
    public GameObject startMenu;
    public GameObject selectMenu;
    public GameObject ui;
    public GameObject finishMenu;

    [Header("Text")]
    public TextMeshProUGUI bestLapTimetext;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI curTimeText;
    public TextMeshProUGUI curSpeedText;
    public TextMeshProUGUI[] lapTimeText;

    float curTime;
    float bestLapTime;

    // 추가
    //public NetworkObject Local;
    //public GameObject localPlayer;

    public BasicSpawner BS;

    public GameObject startUI;

    public GameObject RoomCode;
    public GameObject RoomCodeUI;
    public string roomCode;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //SpeedSet();
        BestLapTimeSet();
    }

    public void showStartUI()
    {
        startUI.SetActive(true);
    }

    //스타트 버튼을 누르면 모든 클라이언트 스타트함수 호출
    public void ClickStartGame()
    {
        Debug.Log("시작버튼 클릭");
        startUI.SetActive(false);
        
        BS.RPC_StartGame();
    }

    //// 네트워크에서 받을 스타트 함수
    //[Rpc(sources: RpcSources.All, targets: RpcTargets.All)]
    //public void RPC_StartGame()
    //{
    //    Debug.Log("RPC통신으로 시작함수 실행");
    //    GameStart();
    //}

    //3바퀴 끝났면 점수 환산 + 서버 통신 + UI 키기
    public void EndGame()
    {
        finishMenu.SetActive(true);
        float score;
        //점수 계산
        // 기준시간은 4분
        //4분 == 240.00
        // 임시
        if(curTime >= 120f)
        {
            score = 0;
        }
        else
        {
            score = 120f - curTime;
        }
        // 서버 통신하는 함수
        // RN에서 받아온 유저 아이디로 보내기
        NetworkManager.networkManager.SendScore((float)Math.Round(score, 2));
    }



    public void SetSessionName()
    {
        roomCode = RoomCode.GetComponent<TMP_InputField>().text;
        //GameObject.Find("BasicSpawner").GetComponent<BasicSpawner>().RoomName = RoomCode.GetComponent<TMP_InputField>().text;
        RoomCodeUI.SetActive(false);
        selectMenu.SetActive(true);
    }

    public void GameStart()
    {
        Debug.Log("게임 시작");
        StartCoroutine("StartCount");
    }

    void BestLapTimeSet()
    {
        bestLapTime = PlayerPrefs.GetFloat("BestLap");
        bestLapTimetext.text =
                    string.Format("Best {0:00}:{1:00.00}",
                    (int)(bestLapTime / 60 % 60), bestLapTime % 60);

        if (bestLapTime == 0)
            bestLapTimetext.text = "Best    -";
    }

    public void LapTime()
    {
        //if(lap == 3)
        if(lap == 1)
        {
            SE_Manager.instance.PlaySound(SE_Manager.instance.goal);
            cam.parent = null;
            StopCoroutine("Timer");
            EndGame();
            //finishMenu.SetActive(true);

            player.player = false;
            player.StartAI();
            controllPad.gameObject.SetActive(false);
            player.transform.GetChild(3).gameObject.SetActive(false);

            if (curTime < bestLapTime | bestLapTime == 0)
            {
                bestLapTimetext.gameObject.SetActive(false);
                bestLapTimetext.text =
                    string.Format("Best {0:00}:{1:00.00}",
                    (int)(curTime / 60 % 60), curTime % 60);
                bestLapTimetext.gameObject.SetActive(true);

                PlayerPrefs.SetFloat("BestLap", curTime);
            }

            // 마지막 UI 보여주기 + 서버로 점수 보내기

            // UI에서 돌아가기 누르면 React Native로 돌아가기
        }

        Debug.Log($"curTime : {curTime}");

        lapTimeText[lap - 1].gameObject.SetActive(false);
        lapTimeText[lap - 1].text =
            string.Format("{0:00}:{1:00.00}",
            (int)(curTime/60%60), curTime % 60);
        lapTimeText[lap - 1].gameObject.SetActive(true);
    }

    IEnumerator StartCount()
    {
        //selectMenu.SetActive(false);
        ui.SetActive(true);

        SE_Manager.instance.PlaySound(SE_Manager.instance.count[3]);
        countText.text = "3";
        countText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        SE_Manager.instance.PlaySound(SE_Manager.instance.count[2]);
        countText.gameObject.SetActive(false);
        countText.text = "2";
        countText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        SE_Manager.instance.PlaySound(SE_Manager.instance.count[1]);
        countText.gameObject.SetActive(false);
        countText.text = "1";
        countText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        SE_Manager.instance.PlaySound(SE_Manager.instance.count[0]);
        countText.gameObject.SetActive(false);
        countText.text = "GO!";
        countText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        countText.gameObject.SetActive(false);

        controllPad.gameObject.SetActive(true);
        player.player = true;
        check = true;

        controllPad.StartController();
        //for(int i = 0; i < car.Length; i++)
        //{
        //    car[i].StartAI();
        //}

        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while(true)
        {
            curTime += Time.deltaTime;

            curTimeText.text = string.Format("{0:00}:{1:00.00}",
                (int)(curTime/60%60), curTime%60);

            yield return null;
        }
    }

    //속도 랜덤 부여
    //void SpeedSet()
    //{
    //    for(int i = 0; i < car.Length; i++)
    //    {
    //        car[i].carSpeed = Random.Range(baseSpeed, baseSpeed + 0.5f);
    //    }
    //}

    public void zoomIn()
    {
        StartCoroutine("Cam_ZoomIn");
    }

    public void StartBtn()
    {
        SE_Manager.instance.PlaySound(SE_Manager.instance.btn);

        //player = Local.GetComponent<Car>();
        //cam.transform.SetParent(player.transform);
        //Debug.Log("Player : " + player.transform.position.x);
        //cam.transform.SetParent(player.transform);

        startMenu.SetActive(false);
        RoomCodeUI.SetActive(true);
        //selectMenu.SetActive(true);

        //ui.SetActive(true);
        //controllPad.gameObject.SetActive(true);
        //player.player = true;
        //check = true;

        //startMenu.SetActive(false);

        //controllPad.StartController();
    }

    public void ExitGame()
    {
        SE_Manager.instance.PlaySound(SE_Manager.instance.btn);
        RNConnectManager.Instance.ExixGame();
        //SceneManager.LoadScene("Main");
        
        //Addressables.LoadSceneAsync("2");
    }

    IEnumerator Cam_ZoomIn()
    {
        while (true)
        {
            cam.transform.localPosition =
                Vector3.Slerp(cam.transform.localPosition,
                new Vector3(0, 2, -3.5f), 20 * Time.deltaTime);

            if (cam.transform.localPosition.z >= -3.5f)
                StopCoroutine("Cam_ZoomIn");


            yield return null;
        }
    }
}

// 32:29