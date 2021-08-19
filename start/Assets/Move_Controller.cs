using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
//����Ƽ���� �繰�� �����Ҷ� �ڵ����� �߰����� �ش�.

public class Move_Controller : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float Force;
    //public���� ����� �ϸ� ����Ƽ���� ��ġ ������ �����ϴ�.
    //[SerializeField]�� ����ϸ� private ���·� publicó�� ����� �����ϴ�. 

    private Rigidbody Rigid;
    private Transform TransInfo;
    //private Vector3 vPosition;
    int i = 0;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        //TransInfo = GetComponent<Transform>();
        //GetComponent�� ����Ƽ inspextor
    }


    void Start()
    {
        Rigid.useConeFriction = false;
        //vPosition = new Vector3(1.0f, 0.0f, 0.0f);
        Speed = 15.0f;
        Force = 2000.0f;

        //���� ���Ͽ� �̵���Ŵ
       //this.Rigid.AddForce(Vector3.forward * Time.deltaTime * Force);
       //�տ� ��ü�� �΋H���� ���� Ʋ������ ���ư���. 

        //Update �Լ��� ������ ���� ȣ�� �Ǳ� ������ AddForce �Լ��� Update�Լ����� ȣ���ϰ� �Ǹ�
        //�� ������ ���� ���� ���ϰ� �ǹǷ� �ӵ��� ���ߵ�
    }


    void Update()
    {
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

        //�¿�
        float fHor = Input.GetAxis("Horizontal");
        //���Ʒ�
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);
        //( x , y , z)

    }

    //this�� transform�� Move_Controller ��ġ �����̼� ������ �̴�. 
    //Transform �� ������ ����� ���� ������ ����Ѵ�. 
}
