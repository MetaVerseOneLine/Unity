using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class FireEx : MonoBehaviour, IDragHandler
{
    public Text result;
    public string word;

    public RaycastHit hit;
    public Ray ray;

    [SerializeField]
    public GameObject[] elements;
    public GameObject[] names;

    public GameObject flame;
    int onElement;
    string tagname;

    bool mouseOver = false;
    // bool _isTrigger;
    // Vector3 _curPosition;


    public bool quest1;
    public bool quest2;
    public bool quest3;
    public bool quest4;
    public bool quest5;
    public bool quest6;
    public bool quest7;

    //public Quest qs;

    // Start is called before the first frame update
    void Start()
    {
        onElement = -1;
        result = GameObject.Find("ResultText").GetComponent<Text>();
        // qs = gameObject.AddComponent<Quest>();
        //qs = new Quest();

    }

    // IEnumerator OnMouseDown()
    //     {
    //         // 오브젝트의 월드 좌표를 스크린 좌표로 변환
    //         Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
    //         // 오브젝트 월드벡터 - 마우스 월드벡터 (벡터끼리의 차는 서로의 거리와 방향을 뜻함. 여기서는 마우스에서 오브젝트까지의 벡터)
    //         Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));
    //         // 마우스를 누르고 있을때 루프
    //         while (Input.GetMouseButton(0))
    //         {
    //             // 현재 마우스의 스크린좌표
    //             Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
    //             // 마우스 벡터 + 마우스->오브젝트 벡터 = 마우스 월드 좌표
    //             _curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

    //             yield return null;
    //         }
    //     }

    // Update is called once per frame
    void Update()
    {
    //    if (_isTrigger)
    //     {
    //         float step = 5 * Time.deltaTime;

    //         // MoveTowards : 처음 위치에서 목표 위치까지 이동하는 함수

    //         transform.position = Vector3.MoveTowards(transform.position, _curPosition, step);

    //         //여기서 충돌 발생 확인하고 산성 염기성에 따라서 변화하는 것 보여줘야함
    //     }

        // // 초기화
        // if (transform.position == _curPosition)
        // {
        //     _isTrigger = false;
        // }
        if(Input.GetMouseButtonDown(0)){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                
                tagname = hit.collider.tag;
                // print(hit.collider.gameObject.name);
                if (tagname == "바륨(Ba)"){
                    ChangeFlame(0);
                } else if (tagname == "칼슘(Ca)"){
                    ChangeFlame(1);
                } else if (tagname == "구리(Cu)"){
                    ChangeFlame(2);
                } else if (tagname == "칼륨(K)"){
                    ChangeFlame(3);
                } else if (tagname == "리튬(Li)"){
                    ChangeFlame(4);
                } else if (tagname == "나트륨(Na)"){
                    ChangeFlame(5);
                } else if (tagname == "스트론튬(Sr)"){
                    ChangeFlame(6);
                }
            }
        }
    }

    public void ChangeFlame(int element)
    {
        
        if(onElement != -1)
        {
            elements[onElement].SetActive(false);
        }

        onElement = element;
        elements[onElement].SetActive(true);

        ChangeText(onElement);

        // print(tagname);
        //qs.ToggleCheck(tagname);
        //FireEx.GetComponent<Quest>().ToggleCheck(tagname);
        GameObject.Find("Button (Quest)").GetComponent<Quest>().ToggleCheck(tagname);
        //GameObject.Find("Button (Quest)").GetComponent<Quest>().ToggleTest();
    }
    
    public void ChangeText(int onElement) {
        switch (onElement) {
            case 0:
                // print(transform.GetChild(1).gameObject);
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n황록색" +"으로 변합니다";
                // word = names[onElement].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
                // result.text = word  + "\n황록색" +"으로 변합니다";
                break;
            case 1:
                // print(transform.GetChild(1).gameObject);
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n주황색" +"으로 변합니다";
                break;
            case 2:
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n청록색" +"으로 변합니다";
                break;
            case 3:
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname+ "\n보라색" +"으로 변합니다";
                break;
            case 4:
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n빨간색" +"으로 변합니다";
                break;
            case 5:
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n노란색" +"으로 변합니다";
                break;  
            case 6:
                // word = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;
                result.text = tagname  + "\n빨간색" +"으로 변합니다";
                break;                                    
        }
    }

    //void OnMouseEnter(){
    //    mouseOver = true;
    //    // print(gameObject.tag);
    //    // print(GameObject.Find("FlaskName"));


    //    if(mouseOver == true)
    //    {
    //        Debug.Log(gameObject);
    //        GameObject.Find("FlaskName").transform.Find(gameObject.tag).gameObject.transform.position = gameObject.transform.position;
    //        GameObject.Find("FlaskName").transform.Find(gameObject.tag).gameObject.SetActive(true);
    //        //  transform.GetChild(1).gameObject.SetActive(true);
    //    }        
    //    // print("마우스오버");
    //}
    //void OnMouseExit(){
    //    mouseOver = false;
    //    GameObject.Find("FlaskName").transform.Find(gameObject.tag).gameObject.SetActive(false);

    //    // transform.GetChild(1).gameObject.SetActive(false);

    //    // GetComponent<Renderer>().material.SetColor("_Color", startColor);
    //    // print("마우스exit");
    //}

    // void OnMouseUp()
    //     {
    //         _isTrigger = true;
    //     }
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("드래그 시작");
    }
    

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("ddddddddddd");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        transform.position = mousePosition;
    }

    public void OnDrop(PointerEventData eventData) {
    
    }
    public void OnEndDrag(PointerEventData eventData) {
    
    }
}
