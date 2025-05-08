using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 30;
    [SerializeField] private Collider weapon;
    private int _currentHealth;
    private Animator animator;
    private void Awake()
    {
        _currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        DisableWeapon();
    }

    public void EnableWeapon()
    {
        weapon.enabled = true;
    }

    public void DisableWeapon()
    {
        weapon.enabled = false;
    }
    public bool IsDead()
    {
        return _currentHealth <= 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth > 0)
            animator.SetTrigger("hit");
        else
        {
            animator.SetTrigger("death");
 
        }
    }
}
