using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlameGameManager : MonoBehaviour
{   public RaycastHit hit;
    public Ray ray;

    public GameObject[] elements;
    public GameObject flame;

    int onElement;
    // Start is called before the first frame update
    void Start()
    {
        onElement = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFlame(int element)
    {
        if(onElement != -1)
        {
            elements[onElement].SetActive(false);
        }

        onElement = element;
        elements[onElement].SetActive(true);

    }

    public void BackMain(){
        //SceneManager.LoadScene("MainScene");
        //컨트롤러 키기
        ControllerManager.Instance.turnOnJoystick();
        SceneController.Instance.loadSubScene("back");


        // if(Input.GetMouseButtonDown(0)){
        //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        //     if (Physics.Raycast(ray, out hit)) {
        //         print(hit.collider.tag);
        //         if (hit.collider.tag == "BackMain"){
        //             SceneManager.LoadScene("SampleScene");
        //         }
        //     }
        // }
    
    }
}
