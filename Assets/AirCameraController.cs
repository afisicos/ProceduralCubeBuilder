using System.Collections.Generic;
using UnityEngine;

public class AirCameraController : MonoBehaviour
{
    public Transform camera;

    private float xRot = 0, yRot = 0, zPos;

    void Start()
    {
        camera.transform.LookAt(transform.position);
        zPos = camera.transform.position.z;
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            yRot += Input.GetAxis("Mouse X") * 3;
            xRot -= Input.GetAxis("Mouse Y") * 3;
        }

        if (xRot > 80) xRot = 80;
        if (xRot < 10) xRot = 10;

        transform.eulerAngles = new Vector3(xRot, yRot, 0);

        float delta = Input.GetAxis("Mouse ScrollWheel") * ZoomFactor();

        if (delta > 0 && zPos < -5)
            zPos = zPos + delta;
        if (delta < 0 && zPos > -2500)
            zPos = zPos + delta;

        float zSmooth = Mathf.Lerp(camera.transform.localPosition.z, zPos, Time.deltaTime*3);
        Vector3 newPos = camera.transform.localPosition;
        newPos.z = zSmooth;

        camera.transform.localPosition = newPos;
    }

    float ZoomFactor()
    {
        return (-camera.transform.localPosition.z);
    }
}
