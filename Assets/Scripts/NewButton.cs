using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewButton : MonoBehaviour {

	public Text gameOverText;

	void OnMouseUp(){
		gameOverText.gameObject.SetActive(false);
		Application.LoadLevel("Eskiv");
	}
}
