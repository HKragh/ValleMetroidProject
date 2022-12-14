using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkeletonAttack : MonoBehaviour
{
    public Animator anim;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int attackDamage = 10;

    public void Attack(InputAction.CallbackContext context)
    {      
        if(context.phase == InputActionPhase.Started)
        {
            //Play animation
            anim.SetTrigger("Attack");

            //Detect enemies in range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            //Apply damage
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("Skeleton Hit" + enemy.name);

                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage); 
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}
    
    
