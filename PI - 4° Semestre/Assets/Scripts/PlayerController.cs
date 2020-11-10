using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRig;
    public float speed = 10f;
    public float rotateSpeed = 10f;
    float directionX;
    float directionZ;
    Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (transform != null)
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
                var forward = transform.TransformDirection(Vector3.forward);
                float curSpeed = speed * Input.GetAxis("Vertical");
                controller.SimpleMove(forward * curSpeed);
            }
        }
    }


    void FixedUpdate()
    {
       Move();
        
    }

    void Move()
    {
        directionX = Input.GetAxis("Horizontal");
        directionZ = Input.GetAxis("Vertical");

        movement = (directionX * transform.right) + (directionZ * transform.forward);
        playerRig.MovePosition(transform.position + movement * speed * Time.deltaTime);

    }



   
}

