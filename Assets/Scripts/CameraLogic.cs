using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Transform Character;
    public Transform ViewPoint;
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 viewDir = Character.position - new Vector3(transform.position.x, Character.position.y, transform.position.z);
        ViewPoint.forward = viewDir.normalized;

        Vector3 InputDir = ViewPoint.forward * verticalInput + ViewPoint.right * horizontalInput;

        if (InputDir != Vector3.zero)
        {
            Character.forward = Vector3.Slerp(Character.forward, InputDir.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}