using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float speed = 2f;
    public GameObject platform; 
    public Rigidbody2D rb;
    public bool isJumping = false;
    public float jumpPower;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            if (isJumping == false)
            {
                
                rb.AddForce(Vector2.up * jumpPower);
                isJumping = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (platform.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
         
	

