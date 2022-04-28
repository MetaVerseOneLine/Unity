using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fusion;

public class Car : NetworkBehaviour
{
    public float carSpeed;
    public Transform target;
    int nextTarget;
    public bool player;


    // Start is called before the first frame update
    public void StartAI()
    {
        if(!player)
        {
            target = KartGameManager.instance.target[nextTarget];

            GetComponent<NavMeshAgent>().speed = carSpeed;
            StartCoroutine("AI_Move");
            StartCoroutine("AI_Animation");
        }

    }

    // 프리팹 스폰되/
    public override void Spawned()
    {

        Debug.Log("스폰되었습니다");
        // 로컬 사용자면
        if (Object.HasInputAuthority)
        {
            Debug.Log("이건 로컬 플레이어 입니다.");
            //player = true;
            // 로컬플레이어 차량
            KartGameManager.instance.player = this;
            //GameManager.instance.localPlayer = this.gameObject;
            // 카메라 위치 조정
            KartGameManager.instance.cam.SetParent(this.transform);
            // 줌인
            KartGameManager.instance.zoomIn();

            //gameObject.GetComponent<NetworkTransform>().InterpolationDataSource = InterpolationDataSources.NoInterpolation;
        }

        if (GameObject.Find("BasicSpawner").GetComponent<NetworkRunner>().IsSharedModeMasterClient)
        {
            //GameObject.Find("GameManager").GetComponent<GameManager>().showStartUI();
            KartGameManager.instance.showStartUI();
        }
    }

    IEnumerator AI_Move()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);

        while(true)
        {
            float dis = (target.position - transform.position).magnitude;

            if(dis <= 1)
            {
                nextTarget += 1;

                if (nextTarget >= KartGameManager.instance.target.Length)
                    nextTarget = 0;

                target = KartGameManager.instance.target[nextTarget];

                GetComponent<NavMeshAgent>().SetDestination(target.position);
            }

            yield return null;
        }
    }

    IEnumerator AI_Animation()
    {
        Vector3 lastPosition;

        while(true)
        {
            lastPosition = transform.position;
            yield return new WaitForSecondsRealtime(0.03f);

            if((lastPosition - transform.position).magnitude > 0)
            {
                Vector3 dir = transform.InverseTransformPoint(lastPosition);

                // -0.01 ~ 0.01 ( x축 )
                if (dir.x >= -0.01f && dir.x <= 0.01f)
                    GetComponent<Animator>().Play("Ani_Forward");
                // right 애니메이션일때, -0.01f~~~ 
                if (dir.x < -0.01f)
                    GetComponent<Animator>().Play("Ani_Right");
                // left 애니메이션일 때, 0.01f ~~
                if (dir.x > 0.01f)
                    GetComponent<Animator>().Play("Ani_Left");
            }

            if((lastPosition - transform.position).magnitude <= 0)
                GetComponent<Animator>().Play("Ani_Idle");

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if(player)
        {
            Debug.Log("isPlayer");
            if (other.gameObject.tag == "Finish")
            {
                Debug.Log("Finish");
                if (KartGameManager.instance.check)
                {
                    KartGameManager.instance.check = false;

                    if (KartGameManager.instance.lap > 0)
                    {
                        SE_Manager.instance.PlaySound(SE_Manager.instance.lap);

                        KartGameManager.instance.LapTime();
                    }
                }

                KartGameManager.instance.lap += 1;
            }

            if(other.gameObject.tag == "CheckPoint")
            {
                Debug.Log("CheckPoint");
                KartGameManager.instance.check = true;
            }
        }
    }
}
