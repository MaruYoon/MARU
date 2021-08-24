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
        Rigid.useGravity = false;

        TargetPoint.transform.position = this.transform.position;
        //vPosition = new Vector3(1.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Move = false;
        Step = new Vector3(0.0f, 0.0f, 0.0f);

    }


    private void FixedUpdate()
    {
    

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayPoint(ray);
        }

        if (Move == true)
            this.transform.position += Step * Time.deltaTime * Speed;

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

                TargetPoint.transform.position = hit.point;

                Move = true;
                Step = TargetPoint.transform.position - this.transform.position;
                Step.Normalize();
                Step.y = 0;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");

        Move = false;

       //if (other.tag == "Enemy")
       //    Destroy(other.gameObject);

    }



}
