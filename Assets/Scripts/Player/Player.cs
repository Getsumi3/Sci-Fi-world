using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    GunController gunController;

    protected override void Start()
    {
        base.Start();
    }

    void Awake()
    {
        gunController = GetComponent<GunController>();
        OnNewWave(1);
    }

    void OnNewWave(int waveNumber)
    {
        health = startingHealth;
        gunController.EquipGun(waveNumber - 1);
    }

    void Update()
    {
        // Weapon input
        if (Input.GetMouseButton(0))
        {
            gunController.OnTriggerHold();
        }
        if (Input.GetMouseButtonUp(0))
        {
            gunController.OnTriggerRelease();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gunController.Reload();
        }

        if (transform.position.y < -10)
        {
            TakeDamage(health);
        }
    }

    public override void Die()
    {
        //AudioManager.instance.PlaySound("Player Death", transform.position);
        base.Die();
    }


}
