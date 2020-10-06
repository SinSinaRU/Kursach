using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAIMoveableDestination : LinearAI
{
    public GameObject lookAt;
    public float lookspeed = 1f;

    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag(lookAt.tag);
        endPosition = GameObject.FindGameObjectWithTag(endPosition.tag);
        speed /= 25;
    }

    void FixedUpdate()
    {
        Vector3 targetPoint = lookAt.GetComponent<HealthObjects>().transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, endPosition.transform.position, speed * Time.deltaTime);
    }
}
