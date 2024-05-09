using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab; // F�rlat�lacak nesnenin prefab�

    void Update()
    {
        // Klavyeden "Space" tu�una bas�ld���nda
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowProjectile();
        }
    }

    void ThrowProjectile()
    {
        // F�rlat�lacak nesnenin prefab� varsa
        if (projectilePrefab != null)
        {
            // Karakterin pozisyonunda ve d�n���nde klon olu�tur
            GameObject projectileClone = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Rigidbody bile�enini al
            Rigidbody2D rb = projectileClone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Karakterin y�n�nde bir kuvvet uygula (�rne�in, x ekseninde 10 birim/s h�zda)
                rb.velocity = transform.right * 10f; // "transform.right", karakterin y�n�n� ifade eder.
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab is not assigned!");
        }
    }
}
