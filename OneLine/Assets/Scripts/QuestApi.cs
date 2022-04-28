using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
public class QuestJson
{
    public string UserId;
    public int WorldIdx;
    public int QuestIdx;
}


// 퀘스트 한것들
[System.Serializable]
public class DoneQuest
{
    public string questContent;

}
[System.Serializable]
public class DoneQList
{
    public List<DoneQuest> doneQuest;
    public double total;

}

// 퀘스트 안한 것들
[System.Serializable]
public class NotDoneQuest
{
    public int questIdx;
    public string questContent;
}
[System.Serializable]
public class NotDoneQList
{
    public List<NotDoneQuest> Items;
}


public class QuestApi : MonoBehaviour
{
    public int FlameCnt;
    public int LitmusCnt;

    public DoneQList doneQData; // 완료된거 
    public NotDoneQList notDoneQData; // 안된거

    public string RN_user_id;

    void Start()
    {
        // StartCoroutine(GetUserInfo());
        StartCoroutine(GetDoneQuestList());
        StartCoroutine(PostNotDoneQuestCheck());

        // StartCoroutine(UnityWebRequestPOSTTEST());
        // QuestJson input = new QuestJson {
        //     UserId = "test",
        //     WorldIdx = 2,
        //     QuestIdx = 1,
        // };
        // StartCoroutine(PostQuestRegister(input));

        RN_user_id = RNConnectManager.Instance.userId;

    }

    IEnumerator GetUserInfo()
    {
        //int world_idx = 2;
        //string user_id = "test";
        string user_id = RN_user_id;
        string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/User/" + user_id; // 유저정보
                                                                                                            // string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/" + user_id; // 유저별 달성도

        UnityWebRequest www = UnityWebRequest.Get(url);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력
        }
        else
        {
            Debug.Log("error");
        }
    }

    IEnumerator GetDoneQuestList()
    {
        //int world_idx = 2;
        //string user_id = "test";
        string user_id = RN_user_id;
        // string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/User/" + user_id; // 유저정보
        string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/" + user_id; // 유저별 달성도

        UnityWebRequest www = UnityWebRequest.Get(url);  // 보낼 주소와 데이터 입력
        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력

            doneQData = JsonUtility.FromJson<DoneQList>(www.downloadHandler.text);
            // Debug.Log(doneQData.doneQuest[0].questContent);
        }
        else
        {
            Debug.Log("error");
        }

    }

    IEnumerator PostQuestRegister(QuestJson input)
    {
        // string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/Quest"; // 월드별 안한 퀘스트
        string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/Register"; // 퀘스트 한거 등록

        string json = JsonUtility.ToJson(input);

        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();  // 응답 대기

            if (www.error == null)
            {
                Debug.Log(www.downloadHandler.text);    // 데이터 출력
            }
            else
            {
                Debug.Log("error");
            }
        }
    }
    IEnumerator PostNotDoneQuestCheck()
    {
        string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/Quest"; // 월드별 안한 퀘스트
        // string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Achievement/Register"; // 퀘스트 한거 등록

        string user_id = RN_user_id;
        QuestJson input = new QuestJson
        {
            UserId = user_id,
            WorldIdx = 2,
        };

        string json = JsonUtility.ToJson(input);

        using (UnityWebRequest www = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();  // 응답 대기

            if (www.error == null)
            {
                Debug.Log(www.downloadHandler.text);    // 데이터 출력
                notDoneQData = JsonUtility.FromJson<NotDoneQList>("{\"Items\":" + www.downloadHandler.text + "}");
                // print(notDoneQData.Items[0].questIdx);
                // print(www.responseCode);

            }
            else
            {
                Debug.Log("error");
            }
        }
    }
    public void CountLitmus()
    {

    }

    public void CountFlame()
    {
        // 
    }

    public void SendQuest(int QuestIdx)
    {
        QuestJson input = new QuestJson
        {
            UserId = RN_user_id,
            WorldIdx = 2,
            QuestIdx = QuestIdx,
        };
        StartCoroutine(PostQuestRegister(input));
    }
}
