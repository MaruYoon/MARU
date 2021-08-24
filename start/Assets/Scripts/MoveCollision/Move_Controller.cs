using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
//����Ƽ���� �繰�� �����Ҷ� �ڵ����� �߰����� �ش�.

public class Move_Controller : MonoBehaviour
{

    [SerializeField] private float Speed;

    private bool Move;
    private GameObject TargetPoint;
    private Vector3 Step;
    private Rigidbody Rigid;


    void Awake()// ���۳�Ʈ�� �ҷ����� �뵵 , �����ڿ� ���, �ѹ��� ����
    {
        Rigid = GetComponent<Rigidbody>();

        TargetPoint = GameObject.Find("TargetPoint");

        //TransInfo = GetComponent<Transform>();
        //GetComponent�� ����Ƽ inspextor
    }


    void Start()// ��ġ���� �����ϴ� �� // Initialize�� ���, ������ ȣ���
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
