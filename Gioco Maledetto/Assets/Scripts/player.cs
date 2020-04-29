using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class player : MonoBehaviour
{

    [SerializeField] float RunSpeed = 5f;
    [SerializeField] float JumpSpeed = 10f;

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        NoRotation();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is betweeen -1 to +1
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
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 JumpVecityToAdd = new Vector2(0f, JumpSpeed);
            myRigidBody.velocity += JumpVecityToAdd;
        }
    }

    private void NoRotation()
    {
        myRigidBody.transform.localRotation = Quaternion.Euler(0, 0, 0); 
    }
}
