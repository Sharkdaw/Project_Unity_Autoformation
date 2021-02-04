using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float runSpeed = 2f;
    public GameObject platform, bouee; 
    public Rigidbody2D rb;
    public bool isJumping = false;
    public float jumpPower;
    public Sprite newSprite, oldSprite;
    public SpriteRenderer sp;
    public bool Vehicle = false;
    public GameObject AeroBouee;
    public bool Jetpack = false;
    public float jetpackForce = 75.0f;
    public Animator animator;
    float horizontalMove = 0f;
    private bool Islookleft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

        Movement();

        if (Input.GetKey("e")) //Lorsqu'on appuie sur la flèche du haut, si on est devant l'Aéro-Bouée, on change le sprite du slime et on détruit la bouée existante.
        {
            if (Vehicle == true) //Lorsque l'on est devant l'Aéro-Bouée, cette bool s'active.
			{
                sp.sprite = newSprite;

                runSpeed = 5f;

                Jetpack = true;

                isJumping = true;

                animator.SetBool("IsVehicule", true);

                Destroy(bouee);
            }
        }

        if (Input.GetKey("up")) //Lorsqu'on appuie sur la flèche du haut, si on est devant l'Aéro-Bouée, on change le sprite du slime et on détruit la bouée existante.
        {
            if (isJumping == false) //On ne peut sauter que si l'on est en contact avec une surface taggée Ground.
            {
                rb.AddForce(Vector2.up * jumpPower);
                isJumping = true;
                animator.SetBool("IsJumping", true);
            }
        }


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = new Vector2(runSpeed * -1, rb.velocity.y);

        if (Input.GetKey(KeyCode.RightArrow))
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);

        void Movement()
        {
            if (horizontalMove > 0 && Islookleft == true)
            {
                Flip();
            }
            else if (horizontalMove < 0 && Islookleft == false)
            {
                Flip();
            }

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        void Flip()
        {
            Islookleft = !Islookleft;
            float x = transform.localScale.x * -1;
            transform.localScale = new Vector2(x, transform.localScale.y);
        }



        if (Input.GetKey("down")) //Lorsque l'on appuie sur la flèche du bas alors que l'on est avec le sprite du slime en Aéro-Bouée, on retrouve notre sprite d'avant et on perd en vitesse.
        {
            if (sp != newSprite)
            {
                sp.sprite = oldSprite;

                Jetpack = false;

                Vehicle = false;

                runSpeed = 2f;

                isJumping = false;

                animator.SetBool("IsVehicule", false);
            }
        }
    }

    void FixedUpdate()
    {

        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

        if (Jetpack == true)
        {

            bool jetpackActive = Input.GetKey("f");
            if (jetpackActive)
            {
                rb.AddForce(new Vector2(0, jetpackForce));
            }

            isJumping = true;

        }
    }


    void OnCollisionEnter2D(Collision2D col) //Pour empêcher les doubles sauts, il faut être sur le "ground" pour sauter.
    {
        if (platform.tag == "Ground")
        {
            isJumping = false;

            animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Si on passe devant l'Aéro-Bouée, on peut monter dedans.
	{
        if (other.name == "bouee")
		{
            Vehicle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) //Si on s'éloigne de la bouée, on ne peut plus monter.
    {
        if (other.name == "bouee")
        {
            Vehicle = false;
        }
    }
}
         
	

