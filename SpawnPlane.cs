using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour {

    public Transform[] planeSpawns;
    public GameObject plane;


	// Use this for initialization
	void Start (){
        StartCoroutine(BlinkTimer());
	}
	
    void Spawn(){
        for (int i = 0; i < planeSpawns.Length; i++){
            int coinFlip = Random.Range(0, 3);
            if(coinFlip > 0){
                Instantiate(plane, planeSpawns[i].position, Quaternion.identity);
            }
        }
    }

    IEnumerator BlinkTimer(){
        yield return new WaitForSeconds(5);
        Spawn();
        StartCoroutine(BlinkTimer2());
    }

    IEnumerator BlinkTimer2()
    {
        yield return new WaitForSeconds(5);
        Spawn();
        StartCoroutine(BlinkTimer());
    }
}
