using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPoint : MonoBehaviour
{
    public Transform target;
    private Camera camera;

    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(new Vector3
            (target.position.x + offsetX, target.position.y + offsetY, target.position.z + offsetZ));
        transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
    }
}
