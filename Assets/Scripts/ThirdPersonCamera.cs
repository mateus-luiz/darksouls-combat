using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offsetPos;
    
    void Update(){
        cam.transform.position = target.position + offsetPos;
        cam.transform.LookAt(target.position);
    }

}
