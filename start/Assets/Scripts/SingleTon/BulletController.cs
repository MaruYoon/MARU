using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{

    private Rigidbody Rigid;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();

    }

    void Start()
    {
        Rigid.useGravity = false;

        Collider CollObj = GetComponent<CapsuleCollider>();

        CollObj.isTrigger = true;

        Rigid.AddForce(this.transform.forward * 500.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }



}
