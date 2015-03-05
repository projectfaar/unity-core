using UnityEngine;
using System.Collections;

public class getProductByName : MonoBehaviour {
	public static string endpoint = "http://localhost:8080/api/getProductByName?name=";

	public static IEnumerator fetch() {
		WWW www = new WWW(endpoint + "potato");
		Debug.Log ("Fetching");
		yield return www;
		Debug.Log(www.text);
	}
}
