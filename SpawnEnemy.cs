using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public static List<GameObject> enemies = new List<GameObject>();
    float timeRemaining = 5f;
    bool timerIsRunning;
    float spawnRadius = 3;
    Vector3 spawnPos;
    public bool isRunning = false;
    private GameObject newEnemy;
    Vector3 direction;
    public void Start()
    {
        timerIsRunning = true;
        spawnPos = new Vector3(0, 0, 0);
        for (int i = 0; i < 5; i++)
        {
            spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            if (!Physics.CheckSphere(spawnPos, 0.75f))
            {
                newEnemy = Instantiate(enemy, spawnPos, enemy.transform.rotation);
                enemies.Add(newEnemy);

            }
        }

    }
    public void Update()
    {


        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

        }

        else
        {

            for (int i = 0; i < 5; i++)
            {

                spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
                if (!Physics.CheckSphere(spawnPos, 0.75f))
                {
                    newEnemy = Instantiate(enemy, spawnPos, enemy.transform.rotation);
                    enemies.Add(newEnemy);

                }


            }
            timeRemaining = 5f;

        }


        //destroyEnemies();
        if (enemies != null)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                direction = enemies[i].transform.position - Camera.main.transform.position;
                direction = direction.normalized;
                enemies[i].GetComponent<Rigidbody>().AddForce(-direction * 1000f*Time.deltaTime, ForceMode.Force);
                enemies[i].GetComponent<Animation>().Play("Run");
            }

        }

    }
    public static List<GameObject> getEnemyList()
    {
        return enemies;
    }
    public static void setEnemyList(List<GameObject> enemiesUpdated)
    {
       enemies = enemiesUpdated;
    }
    public void removeEnemyFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
    public void destroyEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].transform.position.y < 0 && enemies[i] != null)
            {
                enemies.Remove(enemies[i]);
                Destroy(enemies[i].gameObject);

            }
        }
    }
}
