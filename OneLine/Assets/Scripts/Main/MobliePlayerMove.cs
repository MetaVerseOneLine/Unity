using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobliePlayerMove : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image imageBackground;
    private Image imageController;
    private Vector2 touchPosition;

    private void Awake() {
        imageBackground = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
    }
    // 터치 시작시 1회 IPointerDownHandler
    public void OnPointerDown(PointerEventData eventData){
        // Debug.Log("Touch Begin: "+ eventData);
        imageController.rectTransform.anchoredPosition = Vector2.zero;

    }

    // 터치 상태일때 매 프레임 IDragHandler
    public void OnDrag(PointerEventData eventData){

        touchPosition = Vector2.zero;
        print(eventData.position);
        // 조이스틱의 위치가 어디에 있든 동일한 값을 연산하기 위해
        // touchPosition의 위치값은 이미지의 현재위치를 기준으로
        // 얼마나 떨어져 있는지에 따라 다르게 나온다.
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageBackground.rectTransform, eventData.position, eventData.pressEventCamera, out touchPosition
        ))
        {
            // touchPosition 값의 정규화 [0~1]
            // touchPosition을 이미지 크기로 나눔
            touchPosition.x = (touchPosition.x  / imageBackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y  / imageBackground.rectTransform.sizeDelta.y);

            // touchPosition 값의 정규화 [-n~n]
            // 왼쪽(-1) 중심(0) 오른쪽(1)로 변경하기 위해 touchPosition.x*2-1
            // 아래(-1), 중심(0) 위(1) 로 변경하기 위해 touchPosition.y*2-1
            // 이 수식은 Pivot에 따라 달라진다(좌하단 Pivot 기준)
            touchPosition = new Vector2(touchPosition.x*2 -1, touchPosition.y*2 -1);
            

            // touchPosition 값의 정규화 [-1~1]
            // 가상 조이스틱 배경 이미지 밖으로 터치가 나가게 되면 -1~1보다 큰 값이 나올 수 있다
            // 이때 nomalized를 이용해 -1~1사이의 값으로 정규화
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;
            // Debug.Log("Touch & Drag: "+ eventData);

            // 가상 조이스틱 컨트롤러 이미지 이동
            imageController.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * imageBackground.rectTransform.sizeDelta.x / 2,
                touchPosition.y * imageBackground.rectTransform.sizeDelta.y / 2
            );
        }

    }

    // 터치 종료시 1회 IPointerUpHandler
    public void OnPointerUp(PointerEventData eventData){
        // Debug.Log("Touch Ended: "+ eventData);
        // 터치 종료시 이미지 다시 중앙으로
        imageController.rectTransform.anchoredPosition = Vector2.zero;
        touchPosition = Vector2.zero;
    }

    public float Horizontal() {
        return touchPosition.x;
    }

    public float Vertical(){
        return touchPosition.y;
    }
}
