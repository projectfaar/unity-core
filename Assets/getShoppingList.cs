using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;


public class getShoppingList : MonoBehaviour {
	public static string endpoint = "http://59a1eab1.ngrok.com/api/getShoppingList?token=";
	
	public static IEnumerator fetch(string name, System.Action<arr> result) {
		WWW www = new WWW(endpoint + name);
		yield return www;
		
		JSONNode node = JSON.Parse(www.text);

		int status = node["status"].AsInt;
		if(status == 0) {
			JSONNode list = node["list"];
			JSONArray arr = list.AsArray;

			result(arr);
		} else {
			result(null);
		}
	}
}
