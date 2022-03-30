using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float upspeed;
    private void LateUpdate()
    {
        float upMove = Input.GetAxis("Mouse ScrollWheel");
        transform.Rotate(upMove * Time.deltaTime * upspeed, 0, 0);
    }
    
}
