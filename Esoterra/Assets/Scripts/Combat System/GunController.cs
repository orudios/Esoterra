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

    void ShootWeapon()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyAITest target = hit.transform.GetComponent<EnemyAITest>();
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
