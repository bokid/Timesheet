using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
   
   public Transform firePoint;
   public GameObject bulletPrefab;

   public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void onShoot(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
