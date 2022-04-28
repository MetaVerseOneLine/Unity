using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IPointerUpHandler,
    IPointerDownHandler, IDragHandler
{
    public RectTransform pad;
    public RectTransform stick;
    Vector3 playerRotate;

    Car player;

    Animator playerAni;
    bool onMove;
    float playerSpeed;

    [Header("MiniMap")]
    public GameObject minimap;
    public Transform minimapCam;

    //public GameObject localPlayer;

    public void StartController()
    {
        player = KartGameManager.instance.player;
        //localPlayer = GameManager.instance.localPlayer;
        playerAni = KartGameManager.instance.player.GetComponent<Animator>();
        playerAni.SetBool("IsIdle", true);
        playerAni.SetBool("IsRight", false);
        playerAni.SetBool("IsLeft", false);
        playerAni.SetBool("IsForward", false);

        StartCoroutine("PlayerMove");
    }

    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.localPosition =
            Vector3.ClampMagnitude(eventData.position -
            (Vector2)pad.position, pad.rect.width * 0.5f);

        playerRotate = new Vector3(0, stick.localPosition.x, 0).normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector3.zero;
        playerRotate = Vector3.zero;
    }

    public void OnMove()
    {
        StartCoroutine("Acceleration");
        onMove = true;
    }

    public void OffMove()
    {
        StartCoroutine("Braking");
    }

    IEnumerator PlayerMove()
    {
        minimap.SetActive(true);

        while(true)
        {
            KartGameManager.instance.curSpeedText.text =
                string.Format("{0:000.00}", playerSpeed * 10);

            if(onMove)
            {
                Debug.Log("OnMove");
                player.gameObject.transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
                
                //player.transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

                if (Mathf.Abs(stick.localPosition.x) > pad.rect.width * 0.2f)
                    player.transform.Rotate(playerRotate * 30 * Time.deltaTime);

                if (Mathf.Abs(stick.localPosition.x) > pad.rect.width * 0.2f)
                    player.transform.Rotate(playerRotate * 30 * Time.deltaTime);

                if (Mathf.Abs(stick.localPosition.x) <= pad.rect.width * 0.2f)
                {
                    //playerAni.Play("Ani_Forward");
                    playerAni.SetBool("IsRight", false);
                    playerAni.SetBool("IsLeft", false);
                    playerAni.SetBool("IsForward", true);
                }

                if (stick.localPosition.x > pad.rect.width * 0.2f)
                {
                    //playerAni.Play("Ani_Right");
                    playerAni.SetBool("IsRight", true);
                    playerAni.SetBool("IsLeft", false);
                    playerAni.SetBool("IsForward", false);
                }

                if (stick.localPosition.x < pad.rect.width * -0.2f)
                {
                    //playerAni.Play("Ani_Left");
                    playerAni.SetBool("IsRight", false);
                    playerAni.SetBool("IsLeft", true);
                    playerAni.SetBool("IsForward", false);
                }

                player.transform.GetChild(3).gameObject.SetActive(true);
                player.transform.GetChild(4).gameObject.SetActive(false);
            }

            if (!onMove)
            {
                //playerAni.Play("Ani_Idle");
                playerAni.SetBool("IsRight", false);
                playerAni.SetBool("IsLeft", false);
                playerAni.SetBool("IsForward", false);

                player.transform.GetChild(3).gameObject.SetActive(false);
                player.transform.GetChild(4).gameObject.SetActive(true);
            }

            minimapCam.position = player.transform.position + new Vector3(0, 80, 0);

            yield return null;
        }
    }

    IEnumerator Acceleration()
    {
        Debug.Log("Acceleration");
        StopCoroutine("Braking");

        while (true)
        {
            playerSpeed += 7 * Time.deltaTime;

            if (playerSpeed >= KartGameManager.instance.player.carSpeed)
                playerSpeed -= 10 * Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator Braking()
    {
        StopCoroutine("Acceleration");

        while(true)
        {
            playerSpeed -= 7 * Time.deltaTime;

            if(playerSpeed <= 0)
            {
                playerSpeed = 0;
                onMove = false;
                StopCoroutine("Braking");
            }

            yield return null;
        }
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("클릭했다.@@@@");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnMove();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            OffMove();
        }
    }

}
