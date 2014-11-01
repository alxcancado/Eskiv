using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public float speed = 5;
	public GameObject squarePrefab;
	public GameObject bluePrefab;
	public Text text;
	public int score = 0;

	/* lunar lander control
var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		//transform.Translate(x,y,0,Space.Self);
		rigidbody2D.AddForce(new Vector2(x,y) * speed);
	 */
	void Start(){
		AddRandomSquare ();
		AddRandomEnemy ();
	}

	void FixedUpdate()
	{
		// Moves player left, right, up, down. No collision.
		var x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;
		transform.Translate(x,y,0,Space.Self);

		/*
		if (x != 0)
			rigidbody2D.AddForce(new Vector2(x,0) * speed);
			//rigidbody2D.velocity = new Vector3(0, 10, 0);

		if (y != 0)
		{
			rigidbody2D.AddForce(new Vector2(0,y) * speed);
		}
		 */
	}

	//void OnCollisionEnter2D(Collision2D c) {
	void OnTriggerEnter2D(Collider2D c) {
		//Debug.Log (c.gameObject.tag);
		//col = c;
		if (c.gameObject.tag == "wall"){
			//Debug.Log("GAME OVER");
			Destroy(this.gameObject);
		}

		if (c.gameObject.tag == "enemy"){
			//Debug.Log("GAME OVER");
			Destroy(this.gameObject);
		}

		if (c.gameObject.tag == "item"){
			//Debug.Log("ChOmP!");
			Destroy(c.gameObject);
			AddRandomSquare();
			AddRandomEnemy();
			this.text.text = (score+=5).ToString();
		}
	}

	public void AddRandomSquare(){
		float randomX = Random.Range (-3.1f,5.7f);
		float randomY = Random.Range (4.2f,-4.3f);

		GameObject clone = Instantiate(squarePrefab, transform.position, transform.rotation) as GameObject;
		clone.transform.position =  new Vector3(randomX, randomY, 0); //this.gameObject.transform.position;
	}

	public void AddRandomEnemy(){
		float randomX = Random.Range (-3.1f,5.8f);
		float randomY = Random.Range (4.3f,-4.5f);
		GameObject clone = Instantiate(bluePrefab, transform.position, transform.rotation) as GameObject;
		clone.transform.position =  new Vector3(randomX, randomY, 0); //this.gameObject.transform.position;
		clone.SendMessage("SetSpeed", speed); //set enemy speed

		int direction = Random.Range (0, 2); // 0 Horizontal; 1 Vertical
		Debug.Log (direction);

		clone.SendMessage("SetSpeed", speed); 
		clone.SendMessage("SetDirection", direction);
		//clone.SendMessage("SetPosY", randomY); //using random var gimme random speed for the enemies!
	}
}
