using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
//유니티에서 사물에 적용할때 자동으로 추가시켜 준다.

public class Move_Controller : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float Force;
    //public으로 사용을 하면 유니티에서 수치 변경이 가능하다.
    //[SerializeField]을 사용하면 private 상태로 public처럼 사용이 가능하다. 

    private Rigidbody Rigid;
    private Transform TransInfo;
    //private Vector3 vPosition;
    int i = 0;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        //TransInfo = GetComponent<Transform>();
        //GetComponent는 유니티 inspextor
    }


    void Start()
    {
        Rigid.useConeFriction = false;
        //vPosition = new Vector3(1.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Force = 2000.0f;

        //힘을 가하여 이동시킴
       //this.Rigid.AddForce(Vector3.forward * Time.deltaTime * Force);
       //앞에 물체에 부딫히면 축이 틀어지며 돌아간다. 

        //Update 함수는 프레임 마다 호출 되기 때문에 AddForce 함수를 Update함수에서 호출하게 되면
        //매 프레임 마다 힘을 가하게 되므로 속도가 가중됨
    }


    void Update()
    {
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

        //좌우
        float fHor = Input.GetAxis("Horizontal");
        //위아래
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);
        //( x , y , z)

    }

    //this의 transform은 Move_Controller 위치 로테이션 스케일 이다. 
    //Transform 은 변수를 만들어 값을 넣을때 사용한다. 
}
