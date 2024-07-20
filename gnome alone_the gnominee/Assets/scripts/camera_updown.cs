using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class camera_updown : MonoBehaviour
{
    private float xRotation = 0f;

    [SerializeField] private float mouseSensitivity = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);

        // Get the current rotation
        Vector3 currentRotation = transform.localEulerAngles;

        // Set only the x-axis rotation, keep y and z as they are
        transform.localRotation = Quaternion.Euler(xRotation, currentRotation.y, currentRotation.z);
    }
}
