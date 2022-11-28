using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShoot : MonoBehaviour
{
    public KeyCode shootingKey;
    public Projectile projectileTemplate;
    private Projectile[] projectiles = new Projectile[237];  // array of projectiles
    public List<Projectile> projectileList = new List<Projectile>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootingKey))

        {
            // if shooting key is pressed
            Shoot();
        }
    }

    void Shoot()
    {
        // Generate a projectile
        // make it fly!

        Debug.Log("Shoot");

        Projectile newProjectile = Instantiate(projectileTemplate);
        newProjectile.transform.position = transform.position;
        newProjectile.Setup(10, Vector2.right);
        projectileList.Add(newProjectile);

        // i want to class setup on this new projectile

    }

}

