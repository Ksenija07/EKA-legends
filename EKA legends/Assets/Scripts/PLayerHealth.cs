using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private float timeBetweenHit = 1f;
    [SerializeField] private Collider[] weapons;
    private int _currentHealth;
    private int _currentMaxHealth;

    private float lastHitTime = 0;
    private Animator animator;

    public static bool isAlive = true;

    public void EnableWeapon( )
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = true;
    }

    public void DisableWeapon()
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = false;
    }
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value < 0)
                _currentHealth = 0;
            else
                _currentHealth = value;
        }
    }

    private void Awake()
    {
        _currentHealth = startingHealth;
        _currentMaxHealth = startingHealth;
        animator = GetComponent<Animator>();
        isAlive = true;
        DisableWeapon();
    }

    public float GetHealthRatio()
    {
        return (float)_currentHealth / (float)_currentMaxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("EnemyWeapon") && isAlive && Time.time - lastHitTime > timeBetweenHit)
        {
            TakeDamage(5);
        }
    }

   public void TakeDamage(int damage)
    {
        lastHitTime = Time.time;
        _currentHealth -= damage;
        Debug.Log("current health: " + _currentHealth);
        if (_currentHealth > 0)
            animator.SetTrigger("hurt");
        else
        {
            animator.SetTrigger("death");
            isAlive = false;
        }
    }
}
