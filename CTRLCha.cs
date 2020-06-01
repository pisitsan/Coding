using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTRLCha : MonoBehaviour
{
    //movement
    public float speed;
    Rigidbody RB;
    Animator Anim;
    bool facingRight;

   //jump
    public float jumpheight;
    public bool CharacterOnTheGround = true;
   
    //Climp

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Character control
    private void FixedUpdate()
    {
        //If Press Spacebar character jump
        if (Input.GetAxis("Jump") != 0 && CharacterOnTheGround)
        {
            Anim.SetBool("Jumping", true);
            RB.AddForce(new Vector3(0, jumpheight, 0), ForceMode.Impulse);
            CharacterOnTheGround = false;
        }
        
        float move = Input.GetAxis("Horizontal");
        float Climb = Input.GetAxis("Vertical");

        //If Press Right button or Left button
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            print(111);
            Anim.SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));
            RB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, RB.velocity.y, 0);
        }
        
        else
        {
            Anim.SetFloat("Run", 0);
            Anim.SetFloat("Climp", 0);
            Anim.SetBool("Jumping", false);
        }
        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    }

    //Flip character
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
    
    //Push item in game 
    private void OnCollisionStay(Collision obj)
    {
        if (obj.gameObject.tag == "Block" )
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                obj.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
            else
            {
                obj.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
        }
        else if (obj.gameObject.tag == "Cliff" )
        {
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                print(222);
                Anim.SetFloat("Climp", Mathf.Abs(Input.GetAxis("Vertical")));
                RB.velocity = new Vector3(0, Input.GetAxis("Vertical") * speed, 0);
            }
        }
    }

    private void OnCollisionExit(Collision obj)
    {
        if (obj.gameObject.tag == "Block")
        {
            obj.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        else if (obj.gameObject.tag == "Cliff" )
        {
            Anim.SetFloat("Climp", 0);
        }
    }

    //CancelAnimation
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cliff" )
        {
            CharacterOnTheGround = true;
            Anim.SetBool("Jumping", false);
        }

        if (collision.gameObject.tag == "Block")
        {
            CharacterOnTheGround = true;
        }
    }
}
