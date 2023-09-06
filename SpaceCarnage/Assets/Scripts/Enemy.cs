using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Scoremanager scoreManager;

    public float moveSpeed = 1.0f;
    public float offsetDistance = 1.0f; // ���������� �� ������ � ��������
    public float orbitSpeed = 50.0f; // �������� �������� ������
    private float attackDistance = .8f;
    public float playerHealth = 3f;
    public int DamageAmout = 1;

    public Transform target; // ���� (�����)

    private AudioSource soundSource;
    public AudioClip scorePlus;

    private void Start()
    {
        soundSource = GameObject.FindAnyObjectByType<AudioSource>();

        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Scoremanager>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // ��������������, ��� � ������ ���� ��� "Player"
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

            // ��������� ����� �� ���������� ������ ������ � ��������
            Vector3 orbitPosition = target.position + Quaternion.Euler(0, 0, angleToTarget) * (Vector3.right * offsetDistance);

            // ������� ����� � ����� �� ����������
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
