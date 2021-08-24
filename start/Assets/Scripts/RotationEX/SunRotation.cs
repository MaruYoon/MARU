using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{

    void Update()
    {
        //this.transform.Rotate(this.transform.up * Time.deltaTime * 5.0f);

        float fHor = Input.GetAxis("Horizontal");  
        this.transform.Rotate(Vector3.up, fHor * Time.deltaTime * 10.0f);
    }
}
