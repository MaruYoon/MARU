using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    private GameObject WayPoint;

    private bool Move;

    private Vector3 Step;

    private float Speed;

    private Rigidbody Rigid;

    private float IdleTime;



    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();

        //wayPoint 라는 이름의 가상의 목표지점을 생성
        WayPoint = new GameObject("WayPoint");
        WayPoint.transform.tag = "WayPoint";

        //가상의 목표지점에 콜라이더를 삽입
        WayPoint.AddComponent<SphereCollider>();
        //삽입된 콜라이더레 정보를 받음
        SphereCollider sphere = WayPoint.GetComponent<SphereCollider>();
        //콜라이더의 크기를 변경
        sphere.radius = 0.2f;

        sphere.isTrigger = true;
    }

    private void Start()
    {
        //대기 상태 시간
        IdleTime = 3.0f;

        Speed = 0.05f;
        Rigid.useGravity = false;

        Initialize();
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        if(Move == true)
        {
            this.transform.position += Step * Speed;
            Debug.DrawLine(this.transform.position,WayPoint.transform.position);
        }

        else
        {
            IdleTime -= Time.deltaTime;

            if (IdleTime < 0)
            {
                WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

                Move = true;
                Step = WayPoint.transform.position - this.transform.position;
                Step.Normalize();
                Step.y = 0;

                //3~5초 대기시간 세팅
                IdleTime = Random.Range(3, 5);
            }

        }
    }



    private void Initialize()
    {
        this.transform.parent = GameObject.Find("EnableList").transform;

        //이동 목표위치
        WayPoint.transform.position = new Vector3(
               Random.Range(-25, 25),
               0.0f,
               Random.Range(-25, 25));

        //현재 자신의 위치
        this.transform.position = new Vector3(
           Random.Range(-25, 25),
           0.0f,
           Random.Range(-25, 25));


        Move = true;
        Step = WayPoint.transform.position - this.transform.position;
        Step.Normalize();
        Step.y = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WayPoint")
        {
            Move = false;
        }

        if(other.tag == "Ground")
        {
            Destroy(other.gameObject);
        }





        /*
        if(other.tag != "Enemy")
        {
            Move = false;

            WayPoint = new GameObject("WayPoint");
            WayPoint.tag = "WayPoint";

            WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

            Move = true;
            Step = WayPoint.transform.position - this.transform.position;
            Step.Normalize();
            Step.y = 0;
        }
         */
    }



    /*
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(this.gameObject);
        this.transform.parent = GameObject.Find("DisableList").transform;
        ObjectManager.GetInstance.GetDisableList;
        ObjectManager.GetInstance.GetEnableList;
        this.gameObject.SetActive(false);

        //ObjectManager.GetInstance.GetDisableList.Push(this.gameObject);
       // �ȵǴ� ������ �ڽ��� ������ �ű�ų� ���� �Ҽ� ���� ����
    }
     */

}
