using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;

    public Sprite[] animationS;

    public Sprite newS;

    private int animationF;

    private SpriteRenderer sR;

    public float delay = .5f;

    private float timeElapsed;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        timeElapsed += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (destroyed != null) { 
            this.destroyed.Invoke();
        }

        
        // add the triger to change the animation to the expolsion

        sR.sprite = newS;


        Destroy(gameObject);
        
    }

}
