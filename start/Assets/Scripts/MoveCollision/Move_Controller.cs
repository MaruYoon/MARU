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

    //private Vector3 TargetPoint;
    //public GameObject Target;
    private Vector3 Step;
    //[SerializeField] private float Force;
    //public으로 사용을 하면 유니티에서 수치 변경이 가능하다.
    //[SerializeField]을 사용하면 private 상태로 public처럼 사용이 가능하다. 

    private Rigidbody Rigid;
    private Transform TransInfo;
    //private Vector3 vPosition;
    int i = 0;

    void Awake()// 컴퍼넌트를 불러오는 용도 , 생성자와 비슷, 한번만 생성
    {
        Rigid = GetComponent<Rigidbody>();

        TargetPoint = GameObject.Find("TargetPoint");

        //TransInfo = GetComponent<Transform>();
        //GetComponent는 유니티 inspextor
    }


    void Start()// 수치값을 변경하는 것 // Initialize와 비슷, 여러번 호출됨
    {
        Rigid.useConeFriction = false;

        TargetPoint.transform.position = this.transform.position;
        //vPosition = new Vector3(1.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Move = false;
        Step = new Vector3(0.0f, 0.0f, 0.0f);


       // Force = 2000.0f;

        //힘을 가하여 이동시킴
        //this.Rigid.AddForce(Vector3.forward * Time.deltaTime * Force);
        //앞에 물체에 부딫히면 축이 틀어지며 돌아간다. 

        //Update 함수는 프레임 마다 호출 되기 때문에 AddForce 함수를 Update함수에서 호출하게 되면
        //매 프레임 마다 힘을 가하게 되므로 속도가 가중됨
    }


    private void FixedUpdate()
    {
        /*
        float Key = Input.GetAxis("Q");
        Debug.Log("Q : " + Key);
         */

        /*
        TransInfo.position = new Vector3(
           ((i++)* Time.deltaTime * Speed), 0.0f, 0.0f);
         */

        //기준점이 다름

        //게임 오브젝트 기준으로 이동(로컬)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //절대 좌표 기준으로 이동(월드)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.World);

        //물체를 앞쪽 방향으로 이동(로컬)
        //transform.Translate(0,0, Time.deltaTime* Speed); // TransLate(x,y,z);

        //물체를 앞쪽 방향으로 이동(월드)
        //transform.Translate(0,0, Time.deltaTime* Speed, Space.World); //TransLate(x, y, z, Space);

        //카메라를 기준으로 개체를 앞쪽으로 이동
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed, Camera.main.transform);


        // this.transform.Translate((new Vector3(1.0f, 0.0f, 0.0f)) * Time.deltaTime);
        //this.transform.Translate(vPosition * Time.deltaTime * Speed);
        //this.transform.Translate(Vector3.right * Time.deltaTime * Speed);

        //deltaTime = 프레임과 프레임사이의 간격(시간)을 의미한다.
        //this = 현재 클래스/ Move_Controller의 transform을 뜻한다. 


        //키 입력에 의한 이동방법




        /*
        //좌우
        float fHor = Input.GetAxis("Horizontal");
        //위아래
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);
        //( x , y , z)



        //마우스 입력 확인
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("좌클릭");
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("우클릭");
        }

        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("휠클릭");
        }
         */

        if (Input.GetMouseButton(1))
        {



            if (Move == true)
                this.transform.position += Step * Time.deltaTime * Speed;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            


            /* 멈추게 하는 것
            if (Move == true)
                return; 



            //화면에 있는 마우스 위치로 부터 Ray를 보내기 위해 정보를 기록함.
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Ray가 타겟과 출동했을때 반환 값을 저장하는 곳.
            RaycastHit hit;

            //입력받을땐 in 받아올것이 없다면 out
            //if(Physics.Raycast(Ray 시작 위치와 방향, 출돌한 지점의 정보, Mathf.Infinity = 무한한))
            //해섯 : Ray의 위치와 방향으로 부터 Raypoint를 무한하게 발사하고 충돌이 일어나면 Hit에 정보를 저장함
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Ground")
                {
                    // 해석 : ray의 위치로 부터 hit된 위치까지 선을 그림. 실제게임에서는 안보임
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                    Debug.Log(hit.point);

                    TargetPoint.transform.position = hit.point;

                    Move = true;
                    Step = TargetPoint.transform.position - this.transform.position;
                    Step.Normalize();
                    Step.y = 0;


                    //transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);

                    // transform.position = hit.point;

                }
            }
             */
            /*
            if(this.transform.position.x >  TargetPoint.transform.position.x - 0.5f &&
                this.transform.position.x <  TargetPoint.transform.position.x + 0.5f &&
                this.transform.position.z >  TargetPoint.transform.position.z - 0.5f &&
                this.transform.position.z <  TargetPoint.transform.position.z + 0.5f)
            {
                Move = false;
            }
            else
            {
                Move = true;


                Step = TargetPoint.transform.position - this.transform.position;
                Step.Normalize();
            }
             */

        }



        /*
        if(Move == true)
        {
            //this.transform.LookAt(Step);
            this.transform.position += Step * Time.deltaTime * Speed;

            if (this.transform.position.x > TargetPoint.transform.position.x - 0.5f &&
                this.transform.position.x < TargetPoint.transform.position.x + 0.5f &&
                this.transform.position.z > TargetPoint.transform.position.z - 0.5f &&
                this.transform.position.z < TargetPoint.transform.position.z + 0.5f)
            {
                Move = false;
            }
        }
         */
    }

    //this의 transform은 Move_Controller 위치 로테이션 스케일 이다. 
    //Transform 은 변수를 만들어 값을 넣을때 사용한다. 


    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(TargetPoint, 1.0f);
    }
     */

    void RayPoint(Ray _ray)
    {
        RaycastHit hit;

        //입력받을땐 in 받아올것이 없다면 out
        //if(Physics.Raycast(Ray 시작 위치와 방향, 출돌한 지점의 정보, Mathf.Infinity = 무한한))
        //해섯 : Ray의 위치와 방향으로 부터 Raypoint를 무한하게 발사하고 충돌이 일어나면 Hit에 정보를 저장함
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                // 해석 : ray의 위치로 부터 hit된 위치까지 선을 그림. 실제게임에서는 안보임
                Debug.DrawLine(_ray.origin, hit.point, Color.red);
                Debug.Log(hit.point);

                TargetPoint.transform.position = hit.point;

                Move = true;
                Step = TargetPoint.transform.position - this.transform.position;
                Step.Normalize();
                Step.y = 0;


                //transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);

                // transform.position = hit.point;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        Move = false;
    }



}
