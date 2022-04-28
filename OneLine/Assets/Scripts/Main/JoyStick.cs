using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Start is called before the first frame update

    [SerializeField]
    private RectTransform rect_Background;
    [SerializeField]
    private RectTransform rect_JoyStick;

    private float radius;
    [SerializeField] private Transform Player;
    [SerializeField] private float moveSpeed = 15.0f;
    private bool isTouch;
    private Vector3 movePosition;

    // private Vector3 touchPosition;

    Animator animator;
    bool runUP;
    bool walkUp;

  void Start()
    {
        animator = Player.GetComponent<Animator>();
        radius = rect_Background.rect.width * 0.5f;
        // radius = rect_Background.sizeDelta.y / 2;    
        // StartCoroutine(PlayerMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch){
            // Debug.Log(isTouch);
            Player.transform.position += movePosition;
            // Debug.Log($"test : {Vector3.forward * Time.deltaTime * moveSpeed}");
            // Player.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            // Player.Translate(moveSpeed * touchPosition.x * Time.deltaTime, 0f, moveSpeed * touchPosition.y * Time.deltaTime);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // PointerEventData pointerEventData = eventData as PointerEventData;
        // Vector3 DragPosition = pointerEventData.position;
        // joyVec = (DragPosition - stickFirstPosition).normalized;

        // float stickDistance = Vector3.Distance(DragPosition, stickFirstPosition);

        Vector2 value = eventData.position - (Vector2)rect_Background.position; // 현재 마우스좌표에서 백드라운드 좌표 빼고
        value = Vector2.ClampMagnitude(value, radius); // 반지름만큼 가둠?
        rect_JoyStick.localPosition = value; // 상대적 위치 (부모좌표에서 이만큼 떨어지게 하라)

        value = value.normalized; // 속도값 빠지고 방향만
        movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f,  value.y * moveSpeed * Time.deltaTime);
        // touchPosition = value;

        Player.eulerAngles = new Vector3(0, Mathf.Atan2(value.x, value.y)*Mathf.Rad2Deg, 0);

        // Player.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
        animator.SetBool("isWalk", isTouch);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        // playerRotate = Vector3.zero;
        rect_JoyStick.localPosition = Vector3.zero;
        animator.SetBool("isWalk", isTouch);
    }

    // IEnumerator PlayerMove()
    // {
    //     if(isTouch){
    //         Player.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    //     }

    //     else {

    //     }
    //     yield return null;

    // }

}


