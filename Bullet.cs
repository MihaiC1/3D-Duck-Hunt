using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class Bullet : MonoBehaviour
{

    
    private List<GameObject> updatedEnemies;
    private float score;
    public TMP_Text scoreText;
    public void Start()
    {
        score = 0f;
        updatedEnemies = null;
    }

    public void Update()
    {
        scoreText.text = score.ToString();
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name.Equals("Enemy(Clone)"))
        {
            
            hit.gameObject.GetComponent<Animation>().Play("Death");
            updatedEnemies = SpawnEnemy.getEnemyList();
            updatedEnemies.Remove(hit.gameObject);
            SpawnEnemy.setEnemyList(updatedEnemies);
            Destroy(hit.gameObject, 0.4f);
            Destroy(gameObject);
            Player.setScore(Player.getScore()+Player.getScoreMultiplierLc());
            
        }
    }
    
}
