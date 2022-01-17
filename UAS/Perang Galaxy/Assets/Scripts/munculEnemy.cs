using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munculEnemy : MonoBehaviour {

	private bool spawn = false;
	public float timer = 0;
	private int tipeEnemy = 0;
	private float upDown;
	private float leftRight;
	private float positionX;
	private float positionY;
	private float enemyLevelTimer = 0;
	void OnEnable () {
		vars.level = 1;
	}
	void Update () {
		enemyLevelTimer+=Time.deltaTime;
		if (enemyLevelTimer >= 10) {
			vars.level++;
			enemyLevelTimer = 0;
		}
		if (spawn) {
			spawn = false;
			timer = 0;
			upDown = Random.Range (1, 3);
			positionX = Random.Range (-15, 15);
			while (Mathf.Abs((Mathf.Abs (positionX) - Mathf.Abs (transform.position.x))) < 2f) {
				positionX = Random.Range (-15, 15);
			}
			positionY = Random.Range (-10, 10);
			while (Mathf.Abs((Mathf.Abs (positionY) - Mathf.Abs (transform.position.y))) < 2f) {
				positionY = Random.Range (-10, 10);
			}
	
			tipeEnemy = Random.Range (1, 6);
			if (tipeEnemy == 1) {
				GameObject g = Instantiate (Resources.Load ("enemy"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
			} else if (tipeEnemy == 2) {
				GameObject g = Instantiate (Resources.Load ("enemy1"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
			} else if(tipeEnemy == 3){
				GameObject g = Instantiate (Resources.Load ("enemy2"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
			}else if(tipeEnemy == 4){
				GameObject g = Instantiate (Resources.Load ("enemy3"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
			}else{
				GameObject g = Instantiate (Resources.Load ("asteroid"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
			}

		} else {
			timer += Time.deltaTime;
			if (timer >= 1.5f) {
				spawn = true;
			}
		}
	}
}
