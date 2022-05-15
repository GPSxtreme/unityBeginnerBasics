using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private bool spaceKeyWasPressed ;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent ;
    private bool isGrounded;
    
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spaceKeyWasPressed = true;
        };
       
        horizontalInput = Input.GetAxis("Horizontal");
    }
  
    void FixedUpdate () {
        if(!isGrounded){
            return;
        }
        
        if(spaceKeyWasPressed)
        {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            spaceKeyWasPressed = false;
        }
       
        rigidBodyComponent.velocity = new Vector3(horizontalInput*3 , GetComponent<Rigidbody>().velocity.y, 0); 
    }
    
     void OnCollisionEnter(Collision collision)
    {
        isGrounded = true ;
    } 
    void onCollisionExit(Collision collision)
    {
        isGrounded = false ;
    }
}
