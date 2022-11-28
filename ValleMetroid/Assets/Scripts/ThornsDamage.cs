using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsDamage : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    public GameObject player1;
    public GameObject player2;
    public Transform respawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Player1"))
        {
            player1.transform.position = respawnPoint.position;
        }

        if (collision.gameObject.CompareTag("Player1"))
        {
            player2.transform.position = respawnPoint.position;
        }



    }

}
