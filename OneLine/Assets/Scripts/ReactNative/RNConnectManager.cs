using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class RNConnectManager : MonoBehaviour
{
    public string userId;
    public string worldIdx;

    private Scene scene;

    public static RNConnectManager Instance;

    //public bool isGetData;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log("startRNCon");
        //isGetData = false;
        // 시작되면 RN에 userId, worldIdx 요청

        //UnityMessageManager.Instance.SendMessageToRN("start");

        GetUserId("test1");
        GetWorldIdx("2");
        // 테스트용
        //Addressables.LoadSceneAsync("2");
    }

    public void GetUserId(string id)
    {
        this.userId = id;
    }

    public void GetWorldIdx(string idx)
    {
        this.worldIdx = idx;
        //isGetData = true;
        LoadScene();
    }

    public void LoadScene()
    {
        //Debug.Log("start Kart");
        Addressables.LoadSceneAsync(worldIdx);
    }

    public void exit()
    {
        
    }

    public void ExixGame()
    {
        Debug.Log("exit game");

        SceneManager.LoadScene("Main");
        UnityMessageManager.Instance.SendMessageToRN("exit");
    }
}
