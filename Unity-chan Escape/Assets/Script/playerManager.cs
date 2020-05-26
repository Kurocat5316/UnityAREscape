using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    public Animator anim;
    public Rigidbody rbody;
    //private CharacterController controller;
    //private Vector3 moveVector;

    private float motionX;
    private float motionZ;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        motionX = Input.GetAxis("Horizontal");
        motionZ = Input.GetAxis("Vertical");

        anim.SetFloat("motionX", motionX);
        anim.SetFloat("motionZ", motionZ);

        float moveX = motionX * 30f * Time.deltaTime;
        float moveZ = motionZ * 50f * Time.deltaTime;
        rbody.velocity = new Vector3(moveX, 0f, moveZ);
        //moveVector = Vector3.zero;

        //moveVector.x = motionX * 3f;

        //moveVector.z = 3f;

        //controller.Move(Vector3.forward * Time.deltaTime * 3f);
	}
}
