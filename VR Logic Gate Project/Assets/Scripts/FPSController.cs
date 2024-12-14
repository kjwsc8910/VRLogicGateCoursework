using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{

    public Camera playerCamera;
    public float moveSpeed = 5f;
    public float mouseSens = 2f;
    public float mouseXLimit = 45f;
    public float gravity = 10f;

    Vector3 moveDirection = Vector3.zero;
    float rotX = 0;

    CharacterController characterController;
	public LayerMask mask;

	void Start()
    {

        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        //Movement

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = Input.GetAxis("Vertical") * moveSpeed;
        float curSpeedY = Input.GetAxis("Horizontal") * moveSpeed;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        moveDirection.y = movementDirectionY;

        //Gravity

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity *Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        //Looking

        rotX += -Input.GetAxis("Mouse Y") * mouseSens;
        rotX = Mathf.Clamp(rotX, -mouseXLimit, mouseXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSens, 0);

		//Interacting

		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, Mathf.Infinity, mask))
		{
			var obj = hit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E) && obj != null)
            {
                obj.GetComponent<Switch>().Toggle();
            }
		}


	}
}
