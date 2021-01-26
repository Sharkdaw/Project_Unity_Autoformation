using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bouée : MonoBehaviour
{

    public SpriteRenderer rend;
    public Sprite Slime, SlimeNUE;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Slime = Resources.Load<Sprite>("Slime");
        SlimeNUE = Resources.Load<Sprite>("SlimeNUE");
        rend.sprite = Slime;
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }

}
