using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float enemySpeed = 5;
	public int direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == 0) {
			transform.Translate( new Vector3(enemySpeed, 0, 0 ) * Time.deltaTime);
		} else {
			transform.Translate( new Vector3(0, enemySpeed, 0 ) * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		//Debug.Log (c.gameObject.tag);
		if (c.gameObject.tag == "wall"){
			enemySpeed *= -1;
		}
	}

	public void SetSpeed(float speed){
		this.enemySpeed = speed;
	}

	public void SetDirection(int direction){
		// horizontal or vertical
		this.direction = direction;
		// positive or negative
		if ((Random.Range (0, 1)) == 0) {
			this.enemySpeed *= -1;
		}

	}


}
