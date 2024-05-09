using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab; // Fýrlatýlacak nesnenin prefabý

    void Update()
    {
        // Klavyeden "Space" tuþuna basýldýðýnda
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowProjectile();
        }
    }

    void ThrowProjectile()
    {
        // Fýrlatýlacak nesnenin prefabý varsa
        if (projectilePrefab != null)
        {
            // Karakterin pozisyonunda ve dönüþünde klon oluþtur
            GameObject projectileClone = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Rigidbody bileþenini al
            Rigidbody2D rb = projectileClone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Karakterin yönünde bir kuvvet uygula (örneðin, x ekseninde 10 birim/s hýzda)
                rb.velocity = transform.right * 10f; // "transform.right", karakterin yönünü ifade eder.
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab is not assigned!");
        }
    }
}
