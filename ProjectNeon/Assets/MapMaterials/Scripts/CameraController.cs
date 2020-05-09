using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float minimumX = -60f;
    float maximumX = 60f;

    public float sensitivity;

    public Camera cam;

    float rotationY = 0f;
    float rotationX = 0f;


	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}

    private void FixedUpdate()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotationX,0,0);

        

    }
}
