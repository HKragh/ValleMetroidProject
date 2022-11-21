using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer2 : MonoBehaviour
{
    public GameObject player2;
    public Transform respawnPoint;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            player2.transform.position = respawnPoint.position;
        }
    }

}
