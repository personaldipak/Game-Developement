using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;

    public Vector3 offset;
    public float zoomspeed = 4f;
    public float minzoom = 5f;
    public float maxzoom = 15f;
    public float yawspeed = 100f;

    private float currentzoom = 10f;
    private float currentyaw = 0f;

    void Update()
    {
        currentzoom -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
        currentzoom = Mathf.Clamp(currentzoom, minzoom, maxzoom);

        currentyaw -= Input.GetAxis("Horizontal") * yawspeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentzoom;
        transform.LookAt(target.position + Vector3.up * 2f);

        transform.RotateAround(target.position, Vector3.up, currentyaw);
    }
}
