using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public Transform shottingOffset;

    public float speed = 5.0f;

    public Bullet bulletPrefab;

    public Projectile lPrefab;

    public AudioSource soundFired;
    public AudioSource playerB;




    // Update is called once per frame
    void Update()
        {
        // calls the rigibody 
       

        //Movement for the player
        float axis = Input.GetAxis("Horizontal");
        transform.position += Vector3.right *axis * speed * Time.deltaTime;


        // Bullet interaction
        if (Input.GetKeyDown(KeyCode.Space))
          {
            //GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            //Bullet bullet = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
            
            //Debug.Log("Bang!");



            // for a new bullet
            Instantiate(lPrefab, shottingOffset.position, Quaternion.identity);
            soundFired.Play();

            

            //Destroy(shot, 3f);

          }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if we get hit by anything then we end the game

        Debug.Log("Game Over");
        playerB.Play();
        Destroy(gameObject);
        SceneManager.LoadScene("Credit Scene");
        //Debug.Log("Game Over");
        
    }




}
