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


    public GameObject EnemyPrefab;


    void Awake()// ���۳�Ʈ�� �ҷ����� �뵵 , �����ڿ� ���, �ѹ��� ����
    {
        //����Ƽ ���� ������Ʈ
        Rigid = GetComponent<Rigidbody>();

        //��ü�� ã�°�(*�ߺ��� �̸��� ������ Ȯ��)
        TargetPoint = GameObject.Find("TargetPoint");


        //TransInfo = GetComponent<Transform>();
        //GetComponent�� ����Ƽ inspextor

        EnemyPrefab = Resources.Load("Prefab/Enemy") as GameObject;

    }


    void Start()// ��ġ���� �����ϴ� �� // Initialize�� ���, ������ ȣ���
    {
        //�������� ��Ȱ��ȭ
        Rigid.useGravity = false;


        //�����Ҷ� TargetPoint ��ġ�� ���� ������Ʈ�� ��ġ�� �ʱ�ȭ
        TargetPoint.transform.position = this.transform.position;
       //������ ������ �ʴ´�.
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

            //GetDisableList �� �ִ� ��ü�� �ϳ� ������
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            //���� ��ü�� Ȱ��ȭ ���� �����·� ����
            Obj.gameObject.SetActive(true);

            //Ȱ��ȭ�� ������Ʈ�� �����ϴ� ����Ʈ�� ���Խ�Ŵ
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
        //��Ȱ��ȭ ���¿��� Ȱ��ȭ ���·� �����ϰ�, ����� ������Ʈ�� 
        //Ȱ��ȭ�� ������Ʈ�� ���ִ� ����Ʈ���� ����� ���������� �����ȴ�. 
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


        //Ű���� �Է� �����̼�
        float fHor = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up * fHor *  10.0f);
 

        if (Move == true)
            this.transform.position += Step * Speed;
        //Step = ����, Speed = �ӵ�, Time.DeltaTime = ������ ������ ������ �Ÿ�

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

                //hit�� ��ġ�� Ÿ�� ��ǥ�� �޾ƿ�
                TargetPoint.transform.position = hit.point;
                //������ Ÿ���� �����ϼ� �ֵ��� true�� ����
                Move = true;
                //(������) - (this�� �����̴� ��ü)
                //������ �ϴ� ���������� �����̰��� �ϴ� ��ü�� ��ǥ�� ���ش�.
                Step = TargetPoint.transform.position - this.transform.position;
                //Ÿ���� ������ �ٶ󺸴� ���͸� ����
                //1���� ���� ������ ������ָ� ���ʹ� ���� ���⸸�� �����µ� �� ������ ����� �ִ°��� Normalize�̴�
                Step.Normalize();
                //player�� y������ ���� ���۵��� �����Ѵ�.
                Step.y = 0;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ��ü�� �̸��� TargetPoint �� �ƴ϶�� �����ϰ� TargetPoint �϶� ����.
        if (other.name == "TargetPoint")
            Move = false;

        if (other.tag == "Enemy")
        {
            //�θ� EnableList���� DisableList�� ����
            other.transform.parent = GameObject.Find("DisableList").transform;

            //��ü �̵�
            ObjectManager.GetInstance.GetDisableList.Push(other.gameObject);

            //EnableList�� �ִ� ��ü ������ ����
            ObjectManager.GetInstance.GetEnableList.Remove(other.gameObject);

            other.gameObject.SetActive(false);
        }

    }



}
