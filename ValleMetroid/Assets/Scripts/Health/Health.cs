using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public PlayerController pC;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public KeyCode damageKey;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        pC.MoveToLastSpawnPoint();

        if(currentHealth > 0)
        {
            //take damage animation her!!!
        }
        else
        {
            if (!dead)
            {
                //Player death animation her!!!

                GetComponent<PlayerController>().enabled = false;
                dead = true;

            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(damageKey))
        {
            TakeDamage(1);
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

}
