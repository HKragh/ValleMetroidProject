using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Vector3 offset;

    private float yValue;

    public void Start()
    {
        yValue = transform.position.y;

    }

    private void LateUpdate()
    {
        transform.position = ((target1.position + target2.position) / 2f) + offset;

        Vector3 currentPossition = transform.position;
        currentPossition.y = yValue;
        transform.position = currentPossition;


        
    }
   


}
