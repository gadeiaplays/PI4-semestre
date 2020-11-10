using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerPosition;
    private Vector3 cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform.GetComponent<Transform>();
        cameraDistance = transform.position / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = playerTransform.position;
        transform.position = playerPosition + cameraDistance;
    }
}
