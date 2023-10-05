using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;

    private Vector3 previousPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Store the initial mouse position when the left mouse button is pressed.
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            // Calculate the mouse movement direction.
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            // Calculate camera rotation based on mouse movement.
            float rotateX = -direction.x * 180; // camera moves horizontally
            float rotateY = direction.y * 180;  // camera moves vertically

            // Set the camera's position to match the target's position.
            cam.transform.position = target.position;

            // Rotate the camera based on mouse movement.
            cam.transform.Rotate(new Vector3(1, 0, 0), rotateY);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotateX, Space.World);

            // Adjust the camera's distance from the target.
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            // Update the previous mouse position for the next frame.
            previousPosition = newPosition;
        }
    }
}
