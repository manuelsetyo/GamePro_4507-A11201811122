﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakanAcakBintang : MonoBehaviour {

	Vector2 currentPosition;
	float newPositionX;
	float newPositionY;
	float randomScale;
	int rotation;
	float t = 0.1f;
	void Start () {
		randomScale = Random.Range (0.08f, 0.12f);
		rotation = Random.Range (-10, 10);
		transform.localScale = new Vector2 (randomScale, randomScale);
		transform.localRotation = Quaternion.Euler (0, 0, rotation);
		currentPosition = transform.position;
		newPositionX = Random.Range (currentPosition.x - 3, currentPosition.x + 3);
		newPositionY = Random.Range (currentPosition.y - 3, currentPosition.y + 3);
		Destroy (GetComponent<gerakanAcakBintang> (), 0.5f);
	}
	void Update () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPositionX, t), Mathf.Lerp(transform.position.y, newPositionY, t), 0);
		t -= 0.05f * Time.deltaTime;
	}
}
