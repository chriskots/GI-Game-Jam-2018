using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {


	// Use this for initialization
	void Start() {
        Vector3 pos = transform.position;
	}

    // Update is called once per frame
    void Update(){
        transform.Translate(-Vector3.right * 5 * Time.deltaTime);
        if(transform.position.x <= -22.5){
            Destroy(gameObject);
        }
    }
}
