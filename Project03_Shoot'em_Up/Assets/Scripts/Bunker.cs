using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    public AudioSource bunkerB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bunkerB.Play();
        Destroy(gameObject);
    }
}
