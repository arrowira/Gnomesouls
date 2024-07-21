using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rightleft : MonoBehaviour
{
    private float xRotation = 0.0f;
    [SerializeField] private float mouseSensitivity = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseX;


        transform.localRotation = Quaternion.Euler(0f, -xRotation, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
