using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsDamage : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
