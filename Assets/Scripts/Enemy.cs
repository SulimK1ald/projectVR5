using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float deathTime = 0.25f;

    public GameObject drop;
    public GameObject dropSpawnPosition;

    private Transform target;
    [SerializeField] private int health;
    public bool GameOver;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameOver = false; 
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
            GO();
        }
    }

    void GO()
    {
        Time.timeScale = 0f;
        GameOver = true;
    }

    public void TakeDamage(int damage)
    {
        if (GameOver == false)
        {
            health = health - damage;
            if (health <= 0)
            {
                StartCoroutine(Death());
            }
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        speed = 0;

        if (drop != null)
        {
            Instantiate(drop, dropSpawnPosition.transform.position, Quaternion.identity);
        }

    }
}
