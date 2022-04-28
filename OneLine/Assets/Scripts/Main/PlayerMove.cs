using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    CharacterController cc;
    public float gravity = -20;
    float yVelocity = 0;
    private JoyStick joystick;

    Animator animator;
    bool runUP;
    bool walkUp;

    [SerializeField]
    // private JoyStick joyStick;

    void Awake(){

        animator = GetComponent<Animator>();
        joystick = GameObject.FindObjectOfType<JoyStick>();
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    void Update()
    {
        // float h = joyStick.Horizontal();
        // float v = joyStick.Vertical();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
   
        transform.LookAt(transform.position + dir);
        dir = Camera.main.transform.TransformDirection(dir);
    
        // if(cc.collisionFlags == CollisionFlags.Below){
        //     yVelocity = 0;
        // }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        walkUp = Input.GetButton("Run");
        animator.SetBool("isWalk", h != 0 || v != 0);
        animator.SetBool("isRun", walkUp);
        if (runUP)
        {
            speed = 10.0f;
        }
        cc.Move(dir * speed * Time.deltaTime);


    }
    
}
