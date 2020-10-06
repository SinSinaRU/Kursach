using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateAround : MonoBehaviour {

    public Planet Object;
	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
    public float turnSpeed = 1f;
    public float DecreaseSpeedPer = 10;
    public float deathPauseTime = 5f;
    public float speedDeathAnim = 10f;
    private float X, Y;
    private bool MouseIn = false;
    private float KoefTurnSpeed;
    private float zoomMaxForAnim;
    private bool isDied = false;

    public void DiedAnim()
    {
        isDied = true;
    }

    public bool returnIsDied()
    {
        return isDied;
    }

    private void StopDiedAnim()
    {
        isDied = false;
    }

    void Start () 
	{
        zoomMaxForAnim = zoomMax;
        KoefTurnSpeed = turnSpeed;
		limit = Mathf.Abs(limit);
		if(limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/2);
		//transform.position = target.position + offset;
	}

    private void OnMouseEnter()
    {
        MouseIn = true;
    }

    private void OnMouseExit()
    {
        MouseIn = false;
    }

    void Update ()
	{
        if (isDied)
        {
            if (zoomMax > 0) zoomMax -= Time.deltaTime * speedDeathAnim * 5;
            else Invoke("StopDiedAnim", deathPauseTime);
        }
        else
        {
            if(zoomMax < zoomMaxForAnim) zoomMax += Time.deltaTime * speedDeathAnim * 2;
        }

        if (MouseIn || Object.getMouseIn())
        {
            KoefTurnSpeed /= 1f + DecreaseSpeedPer / 100f;
        } else
        {
            KoefTurnSpeed *= 1f + (DecreaseSpeedPer / 100f);
            if (KoefTurnSpeed > turnSpeed) KoefTurnSpeed = turnSpeed;
        }
		if(Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		else if(Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		Y += Input.GetAxis("Mouse Y") * sensitivity;
		Y = Mathf.Clamp (Y, -limit, limit);
		transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = Vector3.Slerp(transform.position, transform.localRotation * -offset + target.position, Time.deltaTime * KoefTurnSpeed);
    }
}