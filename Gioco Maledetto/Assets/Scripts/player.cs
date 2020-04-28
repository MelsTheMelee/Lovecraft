using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{

    Rigidbody2D myRigidBody;
    [SerializeField] float Playerspeed = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flipsprite();
    }

    private void Run()
    {
        float ControlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 PlayerVelocity = new Vector2(ControlThrow * Playerspeed, myRigidBody.velocity.y);
        myRigidBody.velocity = PlayerVelocity;
    }

    private void Flipsprite()
    {
        bool Playermoveshorizontally = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (Playermoveshorizontally)
        {
            float VelocitySign = Mathf.Sign(myRigidBody.velocity.x);
            transform.localScale = new Vector2 ( VelocitySign * 0.4654195f, 0.4735687f);
        }

    }
}
