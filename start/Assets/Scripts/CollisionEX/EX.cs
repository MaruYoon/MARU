using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX : MonoBehaviour
{

   // [RequireComponent(typeof(Rigidbody))]

    [SerializeField] private float Speed;
    private Rigidbody Rigid;
    private GameObject TargetPoint;

    private Transform TransInfo;


    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
    }


    void Start()
    {

        Speed = 15.0f;
        Rigid.useConeFriction = false;
        Rigid.useGravity = false;
        TargetPoint = GameObject.Find("TargetPoint");

    }

    private void FixedUpdate()
    {

        float fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ãæµ¹");
    }

}

