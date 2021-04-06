using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject CenterAxis;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float vertMoveSpeed;

    private float xRot = 0f;
    // Update is called once per frame

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;       
            MoveAroundCam();
            MoveCam();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void MoveAroundCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        CenterAxis.transform.Rotate(Vector3.up * mouseX);
    }

    private void MoveCam()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        float up = Input.GetAxis("VerticalMove");

        CenterAxis.transform.position = CenterAxis.transform.position + (CenterAxis.transform.forward * forward * moveSpeed);
        CenterAxis.transform.position = CenterAxis.transform.position + (CenterAxis.transform.right * side * moveSpeed);
        CenterAxis.transform.position = CenterAxis.transform.position + (Vector3.up * up * vertMoveSpeed);
      
    }
}
