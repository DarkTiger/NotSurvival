using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float walkSpeed;
    public float runSpeed;
    public float rotSpeed;
    public float jumpSpeed;
    private bool onGround;
    private Rigidbody rb;
    public Animator anim;
    private float jumpTimer = 0;
    private bool runMode = false;
    ResourcesPlacement resorcesPlacement;
    PlayerConditions playerConditions;
    

    void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        resorcesPlacement = GameObject.Find("ResourcePlacer").GetComponent<ResourcesPlacement>();

        playerConditions = GetComponent<PlayerConditions>();
        
    }
    
	void Update()
    {
        if (!resorcesPlacement.onInstancing && playerConditions.health > 0)
        {
            float speed = walkSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
                runMode = true;
            }
            else
            {
                runMode = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (runMode)
                {
                    anim.SetInteger("Speed", 2);
                }
                else
                {
                    anim.SetInteger("Speed", 1);
                }   
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
                anim.SetInteger("Speed", 1);
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (!anim.GetBool("Jumping"))
                {
                    anim.SetInteger("Speed", 0);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onGround)
                {
                    rb.AddExplosionForce(jumpSpeed, transform.position, 1);
                    anim.SetBool("Jumping", true);
                    jumpTimer = 1f;
                    onGround = false;
                }
            }

            if (!onGround)
            {
                anim.SetBool("Jumping", true);
            }

            if (jumpTimer > 0.5)
            {
                jumpTimer -= Time.deltaTime;
            }
            else if (anim.GetBool("Jumping"))
            {
                anim.SetBool("Jumping", false);
            }
        }
    }


    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.collider.tag);
        if (other.collider.tag == "Ground" || other.collider.tag == "Resource")
        {
            onGround = true;
        }
    }
}
