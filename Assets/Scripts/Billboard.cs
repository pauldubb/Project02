using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;
    
    void Awake()
    {
        cam = Camera.main.GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
