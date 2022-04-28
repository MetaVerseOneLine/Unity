using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fusion;

public class SelectMenu : MonoBehaviour, IPointerDownHandler
{
    public Camera cam;
    public GameObject finalCheckMenu;
    RaycastHit hit;
    bool checking;

    public BasicSpawner basicSpawner;

    public GameObject Cars;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!checking)
        {
            SE_Manager.instance.PlaySound(SE_Manager.instance.btn);

            Ray ray = cam.ScreenPointToRay(eventData.position);
            Physics.Raycast(ray, out hit);

            if (hit.transform != null)
            {
                if (hit.transform.gameObject.tag == "Car")
                {
                    Debug.Log($"name : {hit.transform.name}");
                    int idx = 0;
                    switch (hit.transform.name)
                    {
                        case "CarA":
                            idx = 0;
                            break;
                        case "CarB":
                            idx = 1;
                            break;
                        case "CarC":
                            idx = 2;
                            break;
                        case "CarD":
                            idx = 3;
                            break;
                        case "CarE":
                            idx = 4;
                            break;
                    }

                    //플레이어의 오브젝트 넣기
                    basicSpawner.SetPlayerPrefab(idx);
                    // 이미지 차량 안보이게
                    Cars.SetActive(false);
                    // 셀랙트 메뉴 안보이게
                    this.gameObject.SetActive(false);

                    basicSpawner.StartGame(GameMode.Shared);

                    
                    // player 넣기
                    //GameManager.instance.player = hit.transform.GetComponent<Car>();

                    //checking = true;
                    //cam.transform.SetParent(hit.transform);
                    //StopCoroutine("Cam_ZoomOut");
                    //StartCoroutine("Cam_ZoomIn");
                    //finalCheckMenu.SetActive(true);
                }
            }
        }
    }

    //IEnumerator Cam_ZoomIn()
    //{
    //    while(true)
    //    {
    //        cam.transform.localPosition =
    //            Vector3.Slerp(cam.transform.localPosition,
    //            new Vector3(0, 2, -3.5f), 20 * Time.deltaTime);

    //        if (cam.transform.localPosition.z >= -3.5f)
    //            StopCoroutine("Cam_ZoomIn");


    //        yield return null;
    //    }
    //}

    //public void CancelBtn()
    //{
    //    SE_Manager.instance.PlaySound(SE_Manager.instance.btn);

    //    StopCoroutine("Cam_ZoomIn");
    //    StartCoroutine("Cam_ZoomOut");
    //    finalCheckMenu.SetActive(false);
    //    checking = false;
    //}

    //IEnumerator Cam_ZoomOut()
    //{
    //    while (true)
    //    {
    //        cam.transform.localPosition =
    //            Vector3.Slerp(cam.transform.localPosition,
    //            new Vector3(0, 3, -5f), 20 * Time.deltaTime);

    //        if (cam.transform.localPosition.z <= -5f)
    //        {
    //            StopCoroutine("Cam_ZoomOut");
    //        }
                


    //        yield return null;
    //    }
    //}
}
