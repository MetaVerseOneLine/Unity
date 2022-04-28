using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Data
{
    public string userId;
    public int worldIdx;
    public float myScore;
}

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager networkManager;

    public string user_id;

    void Awake()
    {
        if(networkManager == null)
        {
            networkManager = this;
        }   
    }

    void Start()
    {
        user_id = RNConnectManager.Instance.userId;
        Debug.Log($"user_id : {user_id}");
    }

    public void SendScore(float myScore)
    {
        StartCoroutine(PostScore(user_id, myScore));
    }

    IEnumerator PostScore(string userId, float myScore)
    {
        Debug.Log("PostScore");
        Debug.Log($"UserId : {userId}");
        Debug.Log($"myScore : {myScore}");

        string url = "http://oneline1-dev.eba-njfq6hmd.us-east-1.elasticbeanstalk.com/api/Score/Register";

        Data input = new Data {userId = userId, worldIdx = 2, myScore = myScore };

        string data = JsonUtility.ToJson(input);
        //string data = JsonUtility.ToJson( new { userId = userId, worldIdx = 2, myScore = myScore });

        using (UnityWebRequest request = UnityWebRequest.Post(url, data))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if(request.error == null)
            {
                Debug.Log(request.downloadHandler.text);

            }
            else
            {
                Debug.Log($"error : {request.error}");
            }
        }

    }

}
