using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer1 : MonoBehaviour
{
    public GameObject player1;
    public Transform respawnPoint;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            player1.transform.position = respawnPoint.position;
        }
    }

}
