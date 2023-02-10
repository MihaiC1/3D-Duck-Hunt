using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask layerToHit;
    public GameObject spawnArea;
    public GameObject bullet;
    private List<GameObject> updatedEnemies;
    public Image silverTrophy;

    private static float score;
    private static float scoreMultiplierRC = 1f;
    private static float scoreMultiplierLC = 1.5f;
    public TMP_Text scoreText;
    private int t = 101;
    public void Start(){
        score = 0f;
    }
    public void Update()
    {
        rightClickAttack();
        leftClickAttack();
        scoreText.text = score.ToString();
        if (score == 5f){
            silverTrophy.gameObject.SetActive(true);
            silverTrophy.GetComponent<Animation>().Play("ImageAnimation");
            
        }
    }
    private void rightClickAttack()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(1))
        {

            if (Physics.Raycast(ray, out hit, layerToHit))
            {
                GameObject enemy = hit.transform.gameObject;
                if (enemy.name.Equals("Enemy(Clone)"))
                {
                    
                    enemy.GetComponent<Animation>().Play("Death");
                    
                    updatedEnemies = SpawnEnemy.getEnemyList();
                    updatedEnemies.Remove(enemy);
                    SpawnEnemy.setEnemyList(updatedEnemies);
                    Destroy(enemy,0.4f);
                    score += scoreMultiplierRC;
                    
                }

            }
        }
    }
    private void leftClickAttack()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, layerToHit))
            {
                GameObject enemy = hit.transform.gameObject;
                if (enemy.name.Equals("Enemy(Clone)"))
                {
                    Vector3 spawnPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+1.05f);
                    GameObject newBullet = Instantiate(bullet, spawnPos, bullet.transform.rotation);
                    var direction = enemy.transform.position - transform.position;
                    direction = direction.normalized;
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * 200, ForceMode.Force);
                }
            }
        }
    }
    public static float getScoreMultiplierRc(){
        return scoreMultiplierRC;
    }
    public static float getScoreMultiplierLc(){
        return scoreMultiplierLC;
    }

    public static void setScore(float updatedScore){
       score = updatedScore;
    }
    public static float getScore(){
        return score;
    }
}
