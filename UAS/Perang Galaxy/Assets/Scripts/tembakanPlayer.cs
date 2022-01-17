using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembakanPlayer : MonoBehaviour {
	public GameObject player;
	private GameObject playerObject;
	private AudioSource soundTembak;
	public float timeTembak = 0;
	private float timer = 0.3f;
	void Start() {
		soundTembak = GameObject.Find ("tembakan").GetComponent <AudioSource> ();
		playerObject = GameObject.Find ("senjata");

		if (PlayerPrefs.GetInt ("levelSpeedTembakan") > 1) {
			timeTembak = 0.4f - ((float)PlayerPrefs.GetInt ("levelSpeedTembakan") / 200);
		} else {
			timeTembak = 0.4f;
		}

	}
	void Update () {
		if (player && vars.gameover == false) {
			if (Input.GetKey (KeyCode.A)) {
				if (player.transform.position.x > -16.8f) {
					player.transform.position = new Vector3 (player.transform.position.x - 0.02f, player.transform.position.y);
				}
			}
			if (Input.GetKey (KeyCode.D)) {
				if (player.transform.position.x < 16.8f) {
					player.transform.position = new Vector3 (player.transform.position.x + 0.02f, player.transform.position.y);
				}
			}
			if (Input.GetKey (KeyCode.W)) {
				if (player.transform.position.y < 9.2f) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  + 0.02f);
				}
			}
			if (Input.GetKey (KeyCode.S)) {
				if (player.transform.position.y > -9.2f) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  - 0.02f);
				}
			}
			Vector3 vec = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector3 dir = transform.position - vec;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			player.transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);
		

			vars.angle = player.transform.rotation.eulerAngles.z;

				timer += Time.deltaTime;
				if (timer >= timeTembak) {
					timer = 0;
					soundTembak.Play ();
					GameObject peluru = Instantiate (Resources.Load ("peluru"), new Vector2 (playerObject.transform.position.x, playerObject.transform.position.y), Quaternion.identity) as GameObject;
				}
		} else {
			player = GameObject.Find ("player");
			if (GameObject.Find ("playerPesawat") != null) {
				playerObject = GameObject.Find ("playerPesawat").transform.Find ("senjata").gameObject;

				if (PlayerPrefs.GetInt ("levelSpeedTembakan") > 1) {
					timeTembak = 0.4f - ((float)PlayerPrefs.GetInt ("levelSpeedTembakan") / 200);
				} else {
					timeTembak = 0.4f;
				}

			}
		}
	}
}
