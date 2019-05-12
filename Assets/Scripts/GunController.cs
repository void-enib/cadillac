using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float fireRate;
    public GameObject bullet;
    public Transform spawnBullet;
    public int munition;
    
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setBullet()
    {
        Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
    }

    void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && munition != 0)
        {
            nextFire = Time.time + fireRate;
            setBullet();
            munition--;
        }
    }

    void Target()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Target();
    }
}
