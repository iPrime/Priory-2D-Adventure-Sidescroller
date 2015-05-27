using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	
	public GameObject loadingImage;
	
	public void loadScene(int level) {
		// Loading screen
		loadingImage.SetActive (true);
		Application.LoadLevel (level);
	}
	
}
