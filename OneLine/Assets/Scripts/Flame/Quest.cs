using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject QuestList;
    public Button btn1;
    bool QuestBtn = false;
    public GameObject gb;
    // FireEx fire = new FireEx();
    // public Toggle tg1;
    // public Toggle tg2;
    // public Toggle tg3;
    // public Toggle tg4;
    // public Toggle tg5;
    // public Toggle tg6;
    // public static Toggle tg7;
    // public CompleteText ct;
    // Start is called before the first frame update
    void Awake()
    {
        // tg1 = GameObject.Find("Quest1").transform.GetChild(1).GetComponent<Toggle>();
        // tg2 = GameObject.Find("Quest2").transform.GetChild(1).GetComponent<Toggle>();
        // tg3 = GameObject.Find("Quest3").transform.GetChild(1).GetComponent<Toggle>();
        // tg4 = GameObject.Find("Quest4").transform.GetChild(1).GetComponent<Toggle>();
        // tg5 = GameObject.Find("Quest5").transform.GetChild(1).GetComponent<Toggle>();
        // tg6 = GameObject.Find("Quest6").transform.GetChild(1).GetComponent<Toggle>();
        //tg7 = GameObject.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>();
    }

    void Start()
    {
        // btn1.onClick.AddListener(QuestOnOff);
        QuestList =  GameObject.Find("Canvas(Quest)");
        //quest7 = GameObject.Find("Canvas(Quest)").transform.Find("Content").transform.Find("Quest7").transform.Find("Toggle").gameObject;
        gb = GameObject.Find("Canvas(Quest)");
        // print(gb);
        // print(gb.transform.GetChild(0));
        // print(gb.transform.GetChild(0).GetChild(0));
        // print(gb.transform.GetChild(0).GetChild(0).GetChild(0));


        ///print(gb.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).GetChild(1));
        //gb.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).GetChild(1).GetComponent<Toggle>().isOn = true;
        //gb.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Toggle>().isOn = true;
        //print(quest7);

        // CheckFlameQuest();
        QuestList.transform.GetChild(0).gameObject.SetActive(false);
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuestOnOff(){
        
            QuestBtn = !QuestBtn;
            if (QuestBtn == true) {
                // print("dd");
                CheckFlameQuest();
                QuestList.transform.GetChild(0).gameObject.SetActive(true);
                // GameObject.Find("Canvas(Quest)").SetActive(true);
            } else {
                // print("zz");
               QuestList.transform.GetChild(0).gameObject.SetActive(false);
            }
        
    }

    public void ToggleCheck(string checkname){
        // ???????????? 7???
        // 7?????? ?????? ????????? ??????, ?????? ???????????? ???????????? ????????? true??? ??????
        // ?????? ????????? ?????????? ?????? false????????? true??? ????????? ??????
        // ????????? toggle????????? ?????? ????????? ?????? ????????? false????????? ?????????

        // ??? ??? ??? ??? ??? ??? ??? = ??? ??? ?????? ?????? ??? ??? ???

        // ??? ?????? ??? ??? ??? ??? ???
        // CompleteText ct = GameObject.Find("Text(QuestComplete)").GetComponent<CompleteText>();
        // int ct  = GameObject.Find("Text(QuestComplete)").GetComponent<CompleteText>().num;
        // print(ct);

        GameObject Quest = gb.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        // print(Quest);
        if (checkname == "??????(Ba)"){
            if (Quest.transform.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>().isOn == false){
                
                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(9); // post??????
                Quest.transform.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>().isOn = true; // ?????? toggle?????? 
                StartCoroutine(TextRoutine());
                // GameObject.Find("Canvas").transform.GetChild(5).gameObject.GetComponent<CompleteText>().TextShow();
                // GameObject.Find("Canvas").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                // ct += 1;
            }
        } else if (checkname == "??????(Ca)"){
            
            if (Quest.transform.Find("Quest4").transform.GetChild(1).GetComponent<Toggle>().isOn == false){

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(6);
                Quest.transform.Find("Quest4").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "??????(Cu)"){
            if(Quest.transform.Find("Quest6").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(8);
                Quest.transform.Find("Quest6").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "??????(K)"){
            if(Quest.transform.Find("Quest3").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(5);
                Quest.transform.Find("Quest3").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "??????(Li)"){
            
            if(Quest.transform.Find("Quest1").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(3);
                Quest.transform.Find("Quest1").transform.GetChild(1).GetComponent<Toggle>().isOn = true; 
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "?????????(Na)"){

            GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(4);
            if(Quest.transform.Find("Quest2").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {
                Quest.transform.Find("Quest2").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "????????????(Sr)"){
            
            if(Quest.transform.Find("Quest5").transform.GetChild(1).GetComponent<Toggle>().isOn ==false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(7);
                Quest.transform.Find("Quest5").transform.GetChild(1).GetComponent<Toggle>().isOn = true;     
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        }
    }
        public IEnumerator TextRoutine()
        {
            // Debug.Log("Complete text");
            GameObject gb = GameObject.Find("Canvas(Flame)");
            gb.transform.GetChild(5).GetComponent<Text>().text = "????????? ??????!";
            gb.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            gb.transform.GetChild(5).gameObject.SetActive(false);
        }

    public void CheckFlameQuest()
    {
        GameObject Quest = gb.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        NotDoneQList arr = GameObject.Find("Button (Quest)").GetComponent<QuestApi>().notDoneQData;
        // print("?????????");
        // print("????????? ?????????" + arr.Items);
        foreach (NotDoneQuest item in arr.Items)
        {
            // print("????????? ??????" + item.questIdx);
            if (item.questIdx > 2){
                Quest.transform.GetChild(item.questIdx-3).transform.GetChild(1).GetComponent<Toggle>().isOn = false;
            }
        }

    }    

}
