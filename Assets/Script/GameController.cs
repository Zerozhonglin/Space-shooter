using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;     
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;
	private int score;
	private bool gameOver;
	private bool restart;

	void Start(){  
		
		gameOver = false;
		restart = false;
		gameOverText.text = "";         
		restartText.text = ""; 
		StartCoroutine(SpawnWaves ());
		score = 0;         
		UpdateScore (); 
	}
	void Update(){         
		if (restartText) {             
			if(Input.GetKeyDown(KeyCode.R)){                 
				SceneManager.LoadScene("Main");             
			}         
		}     
	}   
	void UpdateScore(){         
		scoreText.text = "Score:" + score.ToString();     
	}
	public void AddScore(int newScoreValue){         
		score += newScoreValue;         
		UpdateScore ();     
	}   
	IEnumerator  SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) { 
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);         
				Quaternion spawnRotation = Quaternion.identity;           
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait); 
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOverText) {                 
				restartText.text = "Press 'R' for Restart";

				restart = true;             
				break; 

		
			} 
		}
	}
		public void GameOver(){         
			gameOverText.text = "Game Over";       
		gameOver = true; 
   }
}
