using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAIHoldRadius : LinearAI
{
    public GameObject spaceShip;
    public GameObject planet;
    public float lookspeed = 1f;
    public float radius;
    public bool isRotate;
    public float rotateSpeed;
    private Vector3 endPointRadius;

    private void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag(spaceShip.tag);
        planet = GameObject.FindGameObjectWithTag(planet.tag);
        endPosition = GameObject.FindGameObjectWithTag(endPosition.tag);
        CalculateAndMoveEndPoint();
    }

    void FixedUpdate()
    {
        Vector3 targetPointplanet = planet.GetComponent<HealthObjects>().transform.position;
        Vector3 targetPointspaceShip = spaceShip.GetComponent<HealthObjects>().transform.position;
        Quaternion targetRotation;
        if (Vector3.Distance(transform.position, targetPointplanet) > Vector3.Distance(transform.position, targetPointspaceShip))
        {
            targetRotation = Quaternion.LookRotation(targetPointspaceShip - transform.position);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(targetPointplanet - transform.position);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, endPointRadius, speed * Time.deltaTime);
        CalculateAndMoveEndPoint();
    }

    void CalculateAndMoveEndPoint()
    {
        Vector3 targetPointendPos = endPosition.GetComponent<HealthObjects>().transform.position;
        Vector3 targetDir = targetPointendPos - transform.position;
        float angle = Vector3.Angle(endPosition.transform.right, -targetDir);
        if (transform.position.z < 0) angle = -angle;
        if (isRotate)
        {
            angle += rotateSpeed;
        }
        float newX = radius * Mathf.Cos((angle * Mathf.PI) / 180);
        float newZ = radius * Mathf.Sin((angle * Mathf.PI) / 180);
        endPointRadius = new Vector3(endPosition.transform.position.x + newX, endPosition.transform.position.y, endPosition.transform.position.z + newZ);
    }
}
