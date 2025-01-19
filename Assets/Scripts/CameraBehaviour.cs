using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    private Vector3 offset = new Vector3(0, 0, -1);      // Offset from the player
    private float smoothSpeed = 0.125f;  // How smooth the camera moves


    // better for the camera to be in FixedUpdate instead of LateUpdate, the camera doesnt gitter. 
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
