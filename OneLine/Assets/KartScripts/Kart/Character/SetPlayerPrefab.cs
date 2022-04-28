using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetPlayerPrefab : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject BasicSpawner;
    RaycastHit hit;

    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    //void Onclick()
    //{
    //    string name = this.name;

    //    Debug.Log($"name : {name}");

    //    //BasicSpawner.GetComponent<BasicSpawner>().SetPlayerPrefab();
    //}
    

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("@@@@@ OnPointerDown");
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);
        
        if(hit.transform != null)
        {
            if(hit.transform.gameObject.tag == "Car")
            {
                Debug.Log($"name : {hit.transform.name}");
            }
            else
            {
                Debug.Log("is not car");
            }
        }
        else
        {
            Debug.Log("hit.transform is null");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("1111111111");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("222222222222");
    }
}
