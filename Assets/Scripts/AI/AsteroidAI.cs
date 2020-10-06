using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAI : LinearAI
{
    public float rotationForce = 1f;
    public float minimalSpeed = 0.15f;
    public float accelerationDevider = 8;
    private float x, y, z;
    private bool active = true;
    private float newX, newZ;
    private bool isPushed = false;
    private float currentSpeed = 0;

    private void Start()
    {
        GenerateRotationValues();
    }

    void FixedUpdate()
    {
        if (currentSpeed < speed)
        {
            currentSpeed += Time.deltaTime / accelerationDevider;
        }
        transform.Rotate(x, y, z);
        if (isPushed)
        {
            float distance = minimalSpeed + Vector3.Distance(transform.position, new Vector3(newX, transform.position.y, newZ));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(newX, transform.position.y, newZ), distance * Time.deltaTime);
            if (transform.position == new Vector3(newX, 0, newZ))
            {
                PushOFF();
            };
        }
        if (active) transform.position = Vector3.MoveTowards(transform.position, endPosition.transform.position, currentSpeed * Time.deltaTime);
    }

    private void GenerateRotationValues()
    {
        x = Random.Range(-1f, 1f) * rotationForce;
        y = Random.Range(-1f, 1f) * rotationForce;
        z = Random.Range(-1f, 1f) * rotationForce;
    }

    private void PushOFF()
    {
        currentSpeed = 0f;
        active = true;
        isPushed = false;
    }

    private void PushON()
    {
        active = false;
        isPushed = true;
    }

    public void PushObject(float angle, float range, float rangeStart)
    {
        PushON();
        float Xcos = Mathf.Cos((angle * Mathf.PI) / 180);
        float Zsin = Mathf.Sin((angle * Mathf.PI) / 180);
        newX = transform.position.x + range * Xcos;
        newZ = transform.position.z + range * Zsin;
        transform.position = new Vector3(transform.position.x + ((range * Xcos) / (range / rangeStart)), 0, transform.position.z + ((range * Zsin) / (range / rangeStart)));
    }
}
