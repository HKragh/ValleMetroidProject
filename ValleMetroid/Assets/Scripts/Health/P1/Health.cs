using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;


    private void Awake()
    {
        currentHealth = startingHealth;
    }
}
