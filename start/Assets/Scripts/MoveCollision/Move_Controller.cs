using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
//유니티에서 사물에 적용할때 자동으로 추가시켜 준다.

public class Move_Controller : MonoBehaviour
{

    [SerializeField] private float Speed;

    private bool Move;

    private GameObject TargetPoint;
    private Vector3 Step;
    private Rigidbody Rigid;


    public GameObject EnemyPrefab;


    void Awake()// 컴퍼넌트를 불러오는 용도 , 생성자와 비슷, 한번만 생성
    {
        //유니티 내의 컴포넌트
        Rigid = GetComponent<Rigidbody>();

        //객체를 찾는것(*중복된 이름이 없는지 확인)
        TargetPoint = GameObject.Find("TargetPoint");


        //TransInfo = GetComponent<Transform>();
        //GetComponent는 유니티 inspextor

        EnemyPrefab = Resources.Load("Prefab/Enemy") as GameObject;

    }


    void Start()// 수치값을 변경하는 것 // Initialize와 비슷, 여러번 호출됨
    {
        //물리엔진 비활성화
        Rigid.useGravity = false;


        //시작할때 TargetPoint 위치를 현재 오브젝트의 위치로 초기화
        TargetPoint.transform.position = this.transform.position;
       //방향을 가지지 않는다.
        Step = new Vector3(0.0f, 0.0f, 0.0f);

        Speed = 0.5f;

        Move = false;


        new GameObject("EnableList");
        new GameObject("DisableList");

        for (int i = 0; i<5; ++i)
        {
            ObjectManager.GetInstance.AddObject(Instantiate(EnemyPrefab));
        }


    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(ObjectManager.GetInstance.GetDisableList.Count == 0)
            {
                for(int i = 0; i<5; ++i)
                {
                    ObjectManager.GetInstance.AddObject(Instantiate(EnemyPrefab));
                }
            }

            //GetDisableList 에 있는 객체를 하나 버리고
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            //버린 객체를 활성화 시켜 사용상태로 변경
            Obj.gameObject.SetActive(true);

            //활성화된 오브젝트를 관리하는 리스트에 포함시킴
            ObjectManager.GetInstance.GetEnableList.Add(Obj);

            /*
            if (Obj == null)
            {
                for (int i = 0; i < 5; ++i)
                {
                    ObjectManager.GetInstance.AddObject(Instantiate(EnemyPrefab));
                }
            }
             */
        }
        //비활성화 상태에서 활성화 상태로 변경하고, 변경된 오브젝트는 
        //활성화된 오브젝트만 모여있는 리스트에서 사용이 끝날때까지 관리된다. 
    }


    private void FixedUpdate()
    {
        /*
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayPoint(ray);
        }
         */


        //키보드 입력 로테이션
        float fHor = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up * fHor *  10.0f);
 

        if (Move == true)
            this.transform.position += Step * Speed;
        //Step = 방향, Speed = 속도, Time.DeltaTime = 프레임 단위의 일정한 거리

    }


    void RayPoint(Ray _ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                
                Debug.DrawLine(_ray.origin, hit.point, Color.red);
                Debug.Log(hit.point);

                //hit된 위치를 타겟 좌표로 받아옴
                TargetPoint.transform.position = hit.point;
                //생성된 타겟이 움직일수 있도록 true로 변경
                Move = true;
                //(목적지) - (this가 움직이는 객체)
                //가고자 하는 목적지에서 움직이고자 하는 객체의 좌표를 빼준다.
                Step = TargetPoint.transform.position - this.transform.position;
                //타겟의 방향을 바라보는 벡터를 구함
                //1보다 작은 값으로 만들어주면 벡터는 힘과 방향만을 가지는데 그 과정을 만들어 주는것이 Normalize이다
                Step.Normalize();
                //player의 y방향을 없애 오작동을 방지한다.
                Step.y = 0;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //충돌된 객체의 이름이 TargetPoint 가 아니라면 무시하고 TargetPoint 일때 멈춤.
        if (other.name == "TargetPoint")
            Move = false;

        if (other.tag == "Enemy")
        {
            //부모를 EnableList에서 DisableList로 변경
            other.transform.parent = GameObject.Find("DisableList").transform;

            //객체 이동
            ObjectManager.GetInstance.GetDisableList.Push(other.gameObject);

            //EnableList에 있던 객체 참조를 삭제
            ObjectManager.GetInstance.GetEnableList.Remove(other.gameObject);

            other.gameObject.SetActive(false);
        }

    }



}
