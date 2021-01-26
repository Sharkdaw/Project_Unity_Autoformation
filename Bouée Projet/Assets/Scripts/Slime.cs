using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float speed = 2f;
    public GameObject platform, bouee; 
    public Rigidbody2D rb;
    public bool isJumping = false;
    public float jumpPower;
    public Sprite newSprite, oldSprite;
    public SpriteRenderer sp;
    public bool Vehicle = false;
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) //Lorsqu'on appuie sur la flèche du haut, si on est devant l'Aéro-Bouée, on change le sprite du slime et on détruit la bouée existante.
        {

            if (Vehicle == true) //Lorsque l'on est devant l'Aéro-Bouée, cette bool s'active.
			{
               
                sp.sprite = newSprite;

                speed = 5f;
                                                                
                Destroy(bouee);




            }

            if (isJumping == false) //On ne peut sauter que si l'on est en contact avec une surface taggée Ground.
            {
                rb.AddForce(Vector2.up * jumpPower);
                isJumping = true;
            }
           
        }
                

        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.velocity = new Vector2(speed, rb.velocity.y);


        if (Input.GetKey("down")) //Lorsque l'on appuie sur la flèche du bas alors que l'on est avec le sprite du slime en Aéro-Bouée, on retrouve notre sprite d'avant et on perd en vitesse.
        {
            if (sp == newSprite)
            {
                sp.sprite = oldSprite;

               Vehicle = false;

                speed = 2f;
                
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col) //Pour empêcher les doubles sauts, il faut être sur le "ground" pour sauter.
    {
        if (platform.tag == "Ground")
        {
            isJumping = false;
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
         
	

