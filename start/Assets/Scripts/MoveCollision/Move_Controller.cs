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

    //private Vector3 TargetPoint;
    //public GameObject Target;
    private Vector3 Step;
    //[SerializeField] private float Force;
    //public���� ����� �ϸ� ����Ƽ���� ��ġ ������ �����ϴ�.
    //[SerializeField]�� ����ϸ� private ���·� publicó�� ����� �����ϴ�. 

    private Rigidbody Rigid;
    private Transform TransInfo;
    //private Vector3 vPosition;
    int i = 0;

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

        TargetPoint.transform.position = this.transform.position;
        //vPosition = new Vector3(1.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Move = false;
        Step = new Vector3(0.0f, 0.0f, 0.0f);


       // Force = 2000.0f;

        //���� ���Ͽ� �̵���Ŵ
        //this.Rigid.AddForce(Vector3.forward * Time.deltaTime * Force);
        //�տ� ��ü�� �΋H���� ���� Ʋ������ ���ư���. 

        //Update �Լ��� ������ ���� ȣ�� �Ǳ� ������ AddForce �Լ��� Update�Լ����� ȣ���ϰ� �Ǹ�
        //�� ������ ���� ���� ���ϰ� �ǹǷ� �ӵ��� ���ߵ�
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

        //�������� �ٸ�

        //���� ������Ʈ �������� �̵�(����)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //���� ��ǥ �������� �̵�(����)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.World);

        //��ü�� ���� �������� �̵�(����)
        //transform.Translate(0,0, Time.deltaTime* Speed); // TransLate(x,y,z);

        //��ü�� ���� �������� �̵�(����)
        //transform.Translate(0,0, Time.deltaTime* Speed, Space.World); //TransLate(x, y, z, Space);

        //ī�޶� �������� ��ü�� �������� �̵�
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed, Camera.main.transform);


        // this.transform.Translate((new Vector3(1.0f, 0.0f, 0.0f)) * Time.deltaTime);
        //this.transform.Translate(vPosition * Time.deltaTime * Speed);
        //this.transform.Translate(Vector3.right * Time.deltaTime * Speed);

        //deltaTime = �����Ӱ� �����ӻ����� ����(�ð�)�� �ǹ��Ѵ�.
        //this = ���� Ŭ����/ Move_Controller�� transform�� ���Ѵ�. 


        //Ű �Է¿� ���� �̵����




        /*
        //�¿�
        float fHor = Input.GetAxis("Horizontal");
        //���Ʒ�
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);
        //( x , y , z)



        //���콺 �Է� Ȯ��
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("��Ŭ��");
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("��Ŭ��");
        }

        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("��Ŭ��");
        }
         */

        if (Input.GetMouseButton(1))
        {



            if (Move == true)
                this.transform.position += Step * Time.deltaTime * Speed;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            


            /* ���߰� �ϴ� ��
            if (Move == true)
                return; 



            //ȭ�鿡 �ִ� ���콺 ��ġ�� ���� Ray�� ������ ���� ������ �����.
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Ray�� Ÿ�ٰ� �⵿������ ��ȯ ���� �����ϴ� ��.
            RaycastHit hit;

            //�Է¹����� in �޾ƿð��� ���ٸ� out
            //if(Physics.Raycast(Ray ���� ��ġ�� ����, �⵹�� ������ ����, Mathf.Infinity = ������))
            //�ؼ� : Ray�� ��ġ�� �������� ���� Raypoint�� �����ϰ� �߻��ϰ� �浹�� �Ͼ�� Hit�� ������ ������
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Ground")
                {
                    // �ؼ� : ray�� ��ġ�� ���� hit�� ��ġ���� ���� �׸�. �������ӿ����� �Ⱥ���
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

    //this�� transform�� Move_Controller ��ġ �����̼� ������ �̴�. 
    //Transform �� ������ ����� ���� ������ ����Ѵ�. 


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

        //�Է¹����� in �޾ƿð��� ���ٸ� out
        //if(Physics.Raycast(Ray ���� ��ġ�� ����, �⵹�� ������ ����, Mathf.Infinity = ������))
        //�ؼ� : Ray�� ��ġ�� �������� ���� Raypoint�� �����ϰ� �߻��ϰ� �浹�� �Ͼ�� Hit�� ������ ������
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                // �ؼ� : ray�� ��ġ�� ���� hit�� ��ġ���� ���� �׸�. �������ӿ����� �Ⱥ���
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
