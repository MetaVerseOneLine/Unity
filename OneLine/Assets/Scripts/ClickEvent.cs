using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Text textObject;
    private GameObject tg1;
    private GameObject tg2;
    private GameObject sc;

    void Start()
    {
        textObject = GetComponent<Text>();
        GameObject.Find("CanvasUI").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("CanvasUI").transform.GetChild(2).gameObject.SetActive(false);
        //tg2.SetActive(false);
        GameObject.Find("Canvas(Litmus)").transform.GetChild(1).gameObject.SetActive(false);
        //sc.SetActive(false);
    }

    public void Changer()
    { 
        if (textObject.text == "미션숨기기")
        {
            textObject.text = "미션보기";
            
            GameObject.Find("CanvasUI").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("CanvasUI").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("Canvas(Litmus)").transform.GetChild(1).gameObject.SetActive(false);

        }

        else
        {
            textObject.text = "미션숨기기";
            CheckLitmusQuest();
            GameObject.Find("CanvasUI").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("CanvasUI").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.Find("Canvas(Litmus)").transform.GetChild(1).gameObject.SetActive(true);

        }
        
    }

    public void BackMain()
    {
        ControllerManager.Instance.turnOnJoystick();
        //SceneManager.LoadScene("MainScene");
        SceneController.Instance.loadSubScene("back");
    }

    public void CheckLitmusQuest()
    {
        NotDoneQList arr = GameObject.Find("Quest").GetComponent<QuestApi>().notDoneQData;
        // print("코루틴");
        // print("퀘스트 리스트" + arr.Items);
        foreach (NotDoneQuest item in arr.Items)
        {
            // print("퀘스트 번호" + item.questIdx);
            if (item.questIdx <= 2){
                GameObject.Find("CanvasUI").transform.GetChild(item.questIdx).GetComponent<Toggle>().isOn = false;
            }
        }

    }  
}
