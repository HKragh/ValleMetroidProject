using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public KeyCode damageKey;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //take damage
        }
        else
        {
            //Player death
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(damageKey))
        {
            TakeDamage(1);
        }
    }



}
