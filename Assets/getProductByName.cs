using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;

public class ProductInfo {
	public string name;
	public int id, aisle, aislePosition;

	public ProductInfo(string _name, int _id, int _aisle, int _aislePosition) {
		name = _name;
		id = _id;
		aisle = _aisle;
		aislePosition = _aislePosition;
	}
}

public class getProductByName : MonoBehaviour {
	public static string endpoint = "http://59a1eab1.ngrok.com/api/getProductByName?name=";

	public static IEnumerator fetch(string name, System.Action<ProductInfo> result) {
		WWW www = new WWW(endpoint + name);
		yield return www;

		JSONNode node = JSON.Parse(www.text);

		int status = node["status"].AsInt;
		if(status == 0) {
			JSONNode product = node["product"];
			int id = product["name"].AsInt;
			int aisle = product["aisle"].AsInt;
			int aislePosition = product["aislePosition"].AsInt;
			
			result(new ProductInfo(name, id, aisle, aislePosition));
		} else {
			result(null);
		}
	}
}
