using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float minimumX = -60f;
    float maximumX = 60f;
    float minimumY = -360f;
    float maximumY = 360f;

    public float sensitivityX, sensitivityY;

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
        rotationY += Input.GetAxis("Mouse X") * sensitivityY;
        rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

        

    }
}
