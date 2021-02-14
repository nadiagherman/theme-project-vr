using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    // movement speed for a fish
    public float movementSpeed;

    //limit of distance between player and any fish
    public float limit;

    // fish running away speed
    public float fleeSpeed;

    // velocity
     Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        // velocity vector
        velocity = transform.forward * movementSpeed;

        // the CheckPlayerProximity will be called every one second + a random small value, starting from now (Time.time)
        //random number added is so not ALL the fish execute this at the exact same time => it would be called too many times 
        InvokeRepeating("CheckPlayerProximity", Time.time, 1 + UnityEngine.Random.Range(-0.1f, 0.1f));
    }

    void CheckPlayerProximity()
    {
        //location of the player
        Vector3 playerPos = Camera.main.transform.position;

        //check distance
        if (Vector3.Distance(playerPos, transform.position) < limit)
        {
            Flee();
        }
    }
    
    void Flee()
	{
        // generate a random angle
        Vector3 currentEuler = transform.eulerAngles;

        currentEuler.x = UnityEngine.Random.Range(-20, 20);
        currentEuler.y = currentEuler.y * UnityEngine.Random.Range(-30, 30);

        // rotate the fish to the new angle
        transform.eulerAngles = currentEuler;

        // set new velocity (flee speed)
        velocity = transform.forward * fleeSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // v = d / t
        // d = v * t
        Vector3 movement= Time.fixedDeltaTime * velocity;
        // make the fish move => add movement to position
        transform.position += movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if fish runs into something (other than another fish) => reverse direction
        if (!other.CompareTag("Fish"))
        {
            Reverse();
        }
    }


    void Reverse()
	{
        transform.forward *= -1;
        velocity *= -1;
    }
}
