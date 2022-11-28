using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    private float creationTime;
    public void Setup(float speed, Vector2 direction)
    {
        // setup this projectile
        this.speed = speed;
        this.direction = direction;

        // save time of creation
        creationTime = Time.time;
    }

    private void Update()
    {

        if (creationTime + 5 < Time.time)
        {
            Destroy(gameObject);

        }

        transform.position = transform.position + (Vector3)direction * Time.deltaTime * speed;
    }
}