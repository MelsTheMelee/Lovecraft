using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField] float RunSpeed = 5f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] float ClimbSpeed = 100000f;

    Rigidbody2D myRigidBody;
    Collider2D myCollider;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Climb();
        NoRotation();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // value is betweeen -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * RunSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x) * 0.4522512f, 0.4636795f); //if you chance player dimension you have to modify numbers
        }
    }

    private void Jump()
    {
       // if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
      //      return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 JumpVelocityToAdd = new Vector2(0f, JumpSpeed);
            myRigidBody.velocity += JumpVelocityToAdd;
        }
    }

    private void NoRotation()
    {
        myRigidBody.transform.localRotation = Quaternion.Euler(0, 0, 0); 
    }

    private void Climb()
    {
       if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            return;
        }
       else
        {
            float ControlThrow = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, ControlThrow * ClimbSpeed);
            myRigidBody.velocity = climbVelocity;

        }






    }
}
