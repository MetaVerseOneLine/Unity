using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteText : MonoBehaviour
{
    public int num = 1;
    public Text text;

    // void Awake()
    // {
    //     text = GetComponent<Text>();
    //     if (gameObject.activeSelf == true){

    //         StartCoroutine(FadeTextToFullAlpha());
    //     }
    // }
    // public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    // {
    //     text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    //     num += 1;
    //     while (text.color.a < 1.0f)
    //     {
    //         text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
    //         yield return null;
    //     }
    //     StartCoroutine(FadeTextToZero());
    // }

    // public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    // {
    //     text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //     while (text.color.a > 0.0f)
    //     {
    //         text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));

    //         yield return null;
    //         // StartCoroutine(FadeTextToFullAlpha());
    //     }
    //     gameObject.SetActive(false);
    // }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas(Flame)").transform.GetChild(5).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // public void TextShow(){
    //     if ( GameObject.Find("Canvas(Quest)").transform.GetChild(0).GetChild(0).GetChild(0).transform.Find("Quest7").transform.GetChild(1).GetComponent<Toggle>().isOn == true){
    //         StartCoroutine(TextRoutine());
    //     }


    // }

    // public IEnumerator TextRoutine()
    // {
    //     Debug.Log("Complete text");
    //     GameObject gb = GameObject.Find("Canvas");
    //     gb.transform.GetChild(5).gameObject.SetActive(true);
    //     yield return new WaitForSeconds(2.0f);
    //     gb.transform.GetChild(5).gameObject.SetActive(false);
    // }
}
