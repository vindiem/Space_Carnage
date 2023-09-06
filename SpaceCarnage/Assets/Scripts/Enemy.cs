using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Scoremanager scoreManager;

    public float moveSpeed = 1.0f;
    public float offsetDistance = 1.0f; // Расстояние до игрока с оффсетом
    public float orbitSpeed = 50.0f; // Скорость вращения врагов
    private float attackDistance = .8f;
    public float playerHealth = 3f;
    public int DamageAmout = 1;

    public Transform target; // Цель (игрок)

    private AudioSource soundSource;
    public AudioClip scorePlus;

    private void Start()
    {
        soundSource = GameObject.FindAnyObjectByType<AudioSource>();

        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Scoremanager>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // Предполагается, что у игрока есть тег "Player"
    }


    private void Update()
    {
        if (target != null)
        {

            Vector3 directionToTarget = target.position - transform.position;
            float distanceToTarget = directionToTarget.magnitude;


            if (distanceToTarget <= attackDistance)
            { 
                Destroy(gameObject);
            }
           
            
            float angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angleToTarget - 90);

            // Вычисляем точку на окружности вокруг игрока с оффсетом
            Vector3 orbitPosition = target.position + Quaternion.Euler(0, 0, angleToTarget) * (Vector3.right * offsetDistance);

            // Двигаем врага к точке на окружности
            Vector3 moveDirection = (orbitPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            soundSource.PlayOneShot(scorePlus);
            scoreManager.EnemyKilled();
            Destroy(gameObject);
        }
    }
}
