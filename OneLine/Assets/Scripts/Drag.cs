using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    private Collider _collide;
    private Vector3 _curPosition;
    private Vector3 _direction;
    private bool _isTrigger = false;
    private float timer;
    private int waitingTime;
    private GameObject tg1;
    private GameObject tg2;
    private GameObject sc;
    [SerializeField]
    public Text subtext;

    // Start is called before the first frame update
    
    IEnumerator OnMouseDown()
    {
        // 오브젝트의 월드 좌표를 스크린 좌표로 변환
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        // 오브젝트 월드벡터 - 마우스 월드벡터 (벡터끼리의 차는 서로의 거리와 방향을 뜻함. 여기서는 마우스에서 오브젝트까지의 벡터)
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));
        // 마우스를 누르고 있을때 루프
        while (Input.GetMouseButton(0))
        {
            // 현재 마우스의 스크린좌표
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
            // 마우스 벡터 + 마우스->오브젝트 벡터 = 마우스 월드 좌표
            _curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            yield return null;
        }
    }

    void OnMouseUp()
    {
        _isTrigger = true;
    }

    void Start()
    {
        _collide = GetComponent<Collider>();
        timer = 0;
        waitingTime = 2;
        GameObject gb = GameObject.Find("CanvasUI");
        gb.transform.GetChild(1).gameObject.SetActive(false);
        gb.transform.GetChild(2).gameObject.SetActive(false);
        gb = GameObject.Find("Canvas(Litmus)");
        gb.transform.GetChild(1).gameObject.SetActive(false);
        gb.transform.GetChild(2).gameObject.SetActive(false);


        //sc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if (_isTrigger)
        {
            float step = 5 * Time.deltaTime;

            // MoveTowards : 처음 위치에서 목표 위치까지 이동하는 함수

            transform.position = Vector3.MoveTowards(transform.position, _curPosition, step);

            //여기서 충돌 발생 확인하고 산성 염기성에 따라서 변화하는 것 보여줘야함
        }

        // 초기화
        if (transform.position == _curPosition)
        {
            _isTrigger = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.name);
        Renderer co = other.gameObject.GetComponent<Renderer>();

        if (transform.name.Equals("Yum"))
        {
            if (other.gameObject.CompareTag("RedOne"))
            {
                
                StartCoroutine(LerpColor(co));
            }
            
        }

        if (transform.name.Equals("San"))
        {
            if (other.gameObject.CompareTag("BlueTwo"))
            {
                StartCoroutine(LerpColorRed(co));

            }
        }

        StopCoroutine(LerpColor(co));
        StopCoroutine(LerpColorRed(co));
    }

    public IEnumerator LerpColor(Renderer co)
    {
        float progress = 0;
        float increment = 0.02f / 5;
        float smoothness = 0.02f;

        Debug.Log(co.material.color);
        Debug.Log(Color.red);

        while (progress < 1)
        {
            co.material.color = Color.Lerp(Color.red, Color.blue, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }

        GameObject gb = GameObject.Find("CanvasUI");
        GameObject.Find("Quest").GetComponent<QuestApi>().SendQuest(1);
        gb.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
        StartCoroutine(SUBDelay());



    }

    public IEnumerator SUBDelay()
    {
        GameObject gb = GameObject.Find("Canvas(Litmus)");
        gb.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        gb.transform.GetChild(2).gameObject.SetActive(false);
    }

    public IEnumerator LerpColorRed(Renderer co)
    {
        float progress = 0;
        float increment = 0.02f / 5;
        float smoothness = 0.02f;

        Debug.Log(co.material.color);
        Debug.Log(Color.red);

        while (progress < 1)
        {
            co.material.color = Color.Lerp(Color.blue, Color.red, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        GameObject gb = GameObject.Find("CanvasUI");
        GameObject.Find("Quest").GetComponent<QuestApi>().SendQuest(2);

        gb.transform.GetChild(2).GetComponent<Toggle>().isOn = true;

        StartCoroutine(SUBDelay());
    }
}
