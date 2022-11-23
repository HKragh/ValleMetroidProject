using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = ((target1.position + target2.position) / 2f) + offset;

    }
   


}
