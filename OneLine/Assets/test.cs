using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{

    float distance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Debug.Log("onmouse 드래그 합니다");

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("박스에서");
        
    }


}
