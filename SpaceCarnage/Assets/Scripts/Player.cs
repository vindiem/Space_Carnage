using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 180.0f;

    private Player player;

    private HpBar hpbar;

    public float currentHealth = 3f;

    private bool isRotatingRight = true;

    public GameObject BulletPrefab;  
    public Transform StrikePoint;

    private void Start()
    {
        hpbar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();
    }

    private void Update()
    {
        // Поворот персонажа всегда
        if (isRotatingRight)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        // Смена направления при нажатии кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            isRotatingRight = !isRotatingRight;
            Instantiate(BulletPrefab, StrikePoint.position, transform.rotation);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2); // Загрузка третьей сцены
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hpbar.fill -= 0.17f;
            currentHealth -= 0.5f;
        }
    }
}

