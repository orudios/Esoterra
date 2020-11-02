using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootWeapon();
        }
    }

    // Code governing weapon shooting using Raycast
    void ShootWeapon()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            // Defines a target that has been hit based on the EnemyAITest script
            EnemyAITest target = hit.transform.GetComponent<EnemyAITest>();
            // Additionally checks if any world objects have been shot to destroy them if necessary
            CollateralDamage nonEnemyTarget = hit.transform.GetComponent<CollateralDamage>();

            if (target != null)
            {
                target.takeDamage(damage);
            }
            if (nonEnemyTarget != null)
            {
                nonEnemyTarget.takeDamage(damage);
            }
        }
    }
}
