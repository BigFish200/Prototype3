using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    private float verticalInput;
    public float turnSpeed;
    private float horizontalInput;
    private Rigidbody rb;

    //Particles
    public ParticleSystem dustCloud;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //Stops dust cloud
        dustCloud.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);


        //Activate/Deactivate dustClouds
        if (verticalInput > 0 && !dustCloud.isPlaying) 
        {
            dustCloud.Play();
        }
        else if(verticalInput <= 0) 
        {
            dustCloud.Stop();
        }
    }
}
