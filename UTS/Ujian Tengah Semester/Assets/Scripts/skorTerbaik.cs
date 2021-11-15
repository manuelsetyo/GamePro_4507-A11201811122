using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skorTerbaik : MonoBehaviour {

	void OnEnable () {
		GetComponent <Text> ().text = "SKOR TERBAIK : " + PlayerPrefs.GetInt ("skorTerbaik");
	}
}
