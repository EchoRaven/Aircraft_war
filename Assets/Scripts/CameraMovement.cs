using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float upspeed;
    public float rotatespeed;
    [HideInInspector]
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);
    private void Start()
    {
        SetCursorPos(Screen.width / 2, Screen.height / 2);
    }
    private void LateUpdate()
    {
        float upMove = Input.GetAxis("Mouse ScrollWheel");
        transform.Rotate(upMove * Time.deltaTime * upspeed, 0, 0);
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (x != 0 || y != 0)
        {
            this.transform.Rotate(-y * rotatespeed, 0, 0);
            this.transform.Rotate(0, x * rotatespeed, 0, Space.World);
        }
    }
}
