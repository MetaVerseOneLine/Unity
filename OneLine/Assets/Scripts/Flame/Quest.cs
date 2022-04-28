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
        // 퀘스트는 7개
        // 7개의 토글 변수가 있고, 해당 플라스크 클릭하면 변수가 true로 설정
        // 두번 누르면 어캐됌? ㄴㄴ false일때만 true로 바뀌게 설정
        // 그래서 toggle변수에 맞게 체크로 해줌 이것도 false일때만 바뀌게

        // 빨 노 보 주 빨 청 황 = 리 나 칼륨 칼슘 스 구 바

        // 바 칼슘 구 칼 리 나 스
        // CompleteText ct = GameObject.Find("Text(QuestComplete)").GetComponent<CompleteText>();
        // int ct  = GameObject.Find("Text(QuestComplete)").GetComponent<CompleteText>().num;
        // print(ct);

        GameObject Quest = gb.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        // print(Quest);
        if (checkname == "바륨(Ba)"){
            if (Quest.transform.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>().isOn == false){
                
                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(9); // post요청
                Quest.transform.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>().isOn = true; // 이게 toggle체크 
                StartCoroutine(TextRoutine());
                // GameObject.Find("Canvas").transform.GetChild(5).gameObject.GetComponent<CompleteText>().TextShow();
                // GameObject.Find("Canvas").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                // ct += 1;
            }
        } else if (checkname == "칼슘(Ca)"){
            
            if (Quest.transform.Find("Quest4").transform.GetChild(1).GetComponent<Toggle>().isOn == false){

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(6);
                Quest.transform.Find("Quest4").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "구리(Cu)"){
            if(Quest.transform.Find("Quest6").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(8);
                Quest.transform.Find("Quest6").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "칼륨(K)"){
            if(Quest.transform.Find("Quest3").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(5);
                Quest.transform.Find("Quest3").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "리튬(Li)"){
            
            if(Quest.transform.Find("Quest1").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {

                GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(3);
                Quest.transform.Find("Quest1").transform.GetChild(1).GetComponent<Toggle>().isOn = true; 
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "나트륨(Na)"){

            GameObject.Find("Button (Quest)").GetComponent<QuestApi>().SendQuest(4);
            if(Quest.transform.Find("Quest2").transform.GetChild(1).GetComponent<Toggle>().isOn == false) {
                Quest.transform.Find("Quest2").transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                GameObject.Find("Canvas(Flame)").transform.Find("Text(QuestComplete)").gameObject.SetActive(true);
                StartCoroutine(TextRoutine());
            }
        } else if (checkname == "스트론튬(Sr)"){
            
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
            gb.transform.GetChild(5).GetComponent<Text>().text = "퀘스트 완료!";
            gb.transform.GetChild(5).gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            gb.transform.GetChild(5).gameObject.SetActive(false);
        }

    public void CheckFlameQuest()
    {
        GameObject Quest = gb.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        NotDoneQList arr = GameObject.Find("Button (Quest)").GetComponent<QuestApi>().notDoneQData;
        // print("코루틴");
        // print("퀘스트 리스트" + arr.Items);
        foreach (NotDoneQuest item in arr.Items)
        {
            // print("퀘스트 번호" + item.questIdx);
            if (item.questIdx > 2){
                Quest.transform.GetChild(item.questIdx-3).transform.GetChild(1).GetComponent<Toggle>().isOn = false;
            }
        }

    }    

}
