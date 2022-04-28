using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shadow : MonoBehaviour
{
    public GameObject player;
    public MeshRenderer msh;
    public MeshRenderer mshb;

    void Start()
    {
        msh = GameObject.Find("walll").GetComponent<MeshRenderer>();
        mshb = GameObject.Find("boardd").GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (player.transform.position.x > 4.7 && player.transform.position.z > 10)
        {
            msh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            //msh.material.color.a;
        }

        else
        {
            msh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }

        if (player.transform.position.x > 7.9 && player.transform.position.z > 10)
        {
            mshb.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }

        else
        {
            mshb.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
    }
}
