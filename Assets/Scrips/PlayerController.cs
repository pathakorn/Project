using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    // 
    public float forwardSpeed = 5F;
    // 
    public float backwardSpeed = 2F;
    // 
    public float rotateSpeed = 2F;
    // 
    public float jumpSpeed = 8F;
    // 
    public float gravity = 20F;

    // 
    CharacterController character;
    // 
    Vector3 velocity;

    void Start()
    {
        //
        character = GetComponent<CharacterController>();
    }

    void Update()
    {

        float v = Input.GetAxis("Vertical");        // 
        float h = Input.GetAxis("Horizontal");  // 

        if (character.isGrounded)
        {   // 
            velocity = new Vector3(h, 0, v);        // 
                                                    // 
            velocity = transform.TransformDirection(velocity);

            if (v > 0)
            {
                velocity *= forwardSpeed;       // 
            }
            else if (v < 0)
            {
                velocity *= backwardSpeed;  // 
            }

            if (Input.GetKey(KeyCode.Space))
            {   // 
                velocity.y = jumpSpeed;     // 
            }
        }

        velocity.y -= gravity * Time.deltaTime;

        CollisionFlags flag = character.Move(velocity * Time.deltaTime);
        if (flag == CollisionFlags.None)
        {
            // 
        }
        if ((flag & CollisionFlags.Above) == CollisionFlags.Above)
        {
            // 
        }
        if ((flag & CollisionFlags.Sides) == CollisionFlags.Sides)
        {
            // 
        }
        if ((flag & CollisionFlags.Below) == CollisionFlags.Below)
        {
            // 
        }
        // 
        transform.Rotate(0, h * rotateSpeed, 0);
    }
}
