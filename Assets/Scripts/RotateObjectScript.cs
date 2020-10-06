using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectScript : MonoBehaviour
{
    public float lookspeed = 1f;


    void LookOnCursor()
    {   //заставляет персонажа следить за курсором мышки 
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast (ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint (hitdist);
            Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, lookspeed * Time.deltaTime);
        }
    } 

    void Update()
    {
        LookOnCursor();
    }
}
