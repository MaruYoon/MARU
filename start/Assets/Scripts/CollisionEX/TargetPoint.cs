using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(this.transform.position,1.0f);
    }

}
