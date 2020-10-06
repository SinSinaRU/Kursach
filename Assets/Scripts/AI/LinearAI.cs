using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAI : MonoBehaviour
{
    public GameObject endPosition;
    public float speed = 1;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition.transform.position, speed * Time.deltaTime);
    }
}
