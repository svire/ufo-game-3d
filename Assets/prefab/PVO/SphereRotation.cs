using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{

    //This script will rotate the anti-aircraft gun towards the UFO
    public Transform target;
    float speed = 5;
    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);         
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
