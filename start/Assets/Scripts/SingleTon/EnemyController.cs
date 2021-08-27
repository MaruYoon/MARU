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

    private GameObject BulletPrefab;

    private bool BulletCheck;

   


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

        BulletPrefab = Resources.Load("Prefab/Bullet") as GameObject;
    }

    private void Start()
    {
        Speed = 0.05f;

        BulletCheck = false;

        Rigid.useGravity = false;

        this.transform.parent = GameObject.Find("EnableList").transform;

        //현재 자신의 위치
        this.transform.position = new Vector3(
           Random.Range(-25, 25),
           0.0f,
           Random.Range(-25, 25));

        Initialize();

        StartCoroutine("GoBullet");
    }

    private void OnEnable()
    {
        this.transform.parent = GameObject.Find("EnableList").transform;

        //현재 자신의 위치
        this.transform.position = new Vector3(
           Random.Range(-25, 25),
           0.0f,
           Random.Range(-25, 25));

        Initialize();
    }

    private void Update()
    {
        if(BulletCheck == true)
        {
            GameObject Obj = Instantiate(BulletPrefab);

            Obj.gameObject.AddComponent<BulletController>();

            BulletCheck = false;
            StartCoroutine("GoBullet");

        }

    }


    private void FixedUpdate()
    {
        if (Move == true)
        {
            this.transform.position += Step * Speed;
            Debug.DrawLine(this.transform.position, WayPoint.transform.position);
        }
    }

    private void Initialize()
    {


        //이동 목표위치
        WayPoint.transform.position = new Vector3(
               Random.Range(-25, 25),
               0.0f,
               Random.Range(-25, 25));

        Move = true;
        Step = WayPoint.transform.position - this.transform.position;
        Step.Normalize();
        Step.y = 0;


        WayPoint.transform.position.Set(
            WayPoint.transform.position.x,
            0.0f,
            WayPoint.transform.position.z);

        this.transform.LookAt(WayPoint.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            Move = false;
            StartCoroutine("EnemyState");
        }

   
    }

    IEnumerator GoBullet()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        BulletCheck = true;
    }


    IEnumerator EnemyState()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));

            Initialize();

        }
    }
}

