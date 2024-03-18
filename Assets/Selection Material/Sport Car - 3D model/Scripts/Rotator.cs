using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float speed = 50f;
    public float rotationSpeed = 1f;
    public Transform target;
    public float distance = 10f;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0f, speed * Time.deltaTime, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            float rotationX = -delta.y * rotationSpeed;
            float rotationY = delta.x * rotationSpeed;

            // Rotate the target (camera) around the car
            target.RotateAround(transform.position, Vector3.up, rotationY);
            target.RotateAround(transform.position, target.right, rotationX);
        }
    }
}

