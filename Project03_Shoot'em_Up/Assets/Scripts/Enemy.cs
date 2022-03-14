using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{

    public Sprite[] animationSprites;

    public float animationTime = 1.0f;

    private SpriteRenderer spriteRenderer;

    private int animationFrame;

    public System.Action<Enemy> killed;

    public int score = 10;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }

    /**
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
        
    


        //Debug.Log("In_Collsion");
        if (other.gameObject.name == "Laser(Clone)")
        {
            //Debug.Log("Not Destorying/ invisiable");
            killed?.Invoke(this);
            //gameObject.SetActive(false);
        }





    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            //Debug.Log(gameObject.name);
            killed?.Invoke(this);
        }
    }
}
