using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField]
    // private float rotSpeed = 20;

    float mx;
    float my; 

    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float h = Input.GetAxis("Mouse X");
        // float v = Input.GetAxis("Mouse Y");
        // mx += h * rotSpeed * Time.deltaTime;
        // my += v * rotSpeed * Time.deltaTime;

        // my = Mathf.Clamp(my,-60,60);
        // Vector3 dir = new Vector3(-my,mx,0);

        // transform.eulerAngles = dir;
        transform.position = target.position + offset;

    }
}
