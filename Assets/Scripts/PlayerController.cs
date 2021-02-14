using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // rigid body component
    Rigidbody rigidBody;
    
    // movement speed
    public float movementSpeed;


    void Awake()
	{
        rigidBody = GetComponent<Rigidbody>();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
            // we set the velocity of our player to the camera direction * the movement speed
            rigidBody.velocity = movementSpeed * Camera.main.transform.forward;
		}
    }
}
