using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Vector3 direction;
    public void Start(){
        
    }

    public void startRunning(){
        if (gameObject != null){
            direction = gameObject.transform.position - Camera.main.transform.position;
            direction = direction.normalized;
            gameObject.GetComponent<Rigidbody>().AddForce(-direction * 30, ForceMode.Force);
            gameObject.GetComponent<Animation>().Play("Run");
        }
        else{
            Debug.Log("Enemy is already destroyed");
        }
        
    }
    
    public void deathAnimStart(){
        gameObject.GetComponent<Animation>().Play("Death");
    }
}
