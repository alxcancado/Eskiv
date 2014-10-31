using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	float randomX;
	float randomY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( new Vector3(randomX, randomY, 0 ) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D c) {
		Debug.Log (c.gameObject.tag);
		//col = c;
		if (c.gameObject.tag == "wall"){
			randomX *= -1;
			randomY *= -1;
		}
	}
	
	public void SetPosX(float x){
		this.randomX = x;
	}
	public void SetPosY(float y){
		this.randomY = y;
	}


}
