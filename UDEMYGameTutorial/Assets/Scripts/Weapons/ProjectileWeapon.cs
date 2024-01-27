using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    public EnemyDamager damager;
    public DaggerProjectile weaponProjectile;

    private float shotCounter;

    public float weaponRange;
    public LayerMask whatIsEnemy;

    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = stats[weaponLevel].timeBetweenAttacks;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * stats[weaponLevel].range, whatIsEnemy);
            if (enemies.Length > 0)
            {
                for (int i = 0; i < stats[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;

                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    weaponProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Instantiate(weaponProjectile, weaponProjectile.transform.position, weaponProjectile.transform.rotation).gameObject.SetActive(true);
                }

                //SFXManager.instance.PlaySFXPitched(6);
            }
        }
    }

    void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        shotCounter = 0f;

        weaponProjectile.moveSpeed = stats[weaponLevel].speed;
    }
}
