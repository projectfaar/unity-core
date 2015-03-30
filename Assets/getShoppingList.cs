using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;


public class getShoppingList : MonoBehaviour {
	public static string endpoint = "http://43468d42.ngrok.com/api/";
	public static string productName = "getProductByName?name=";
	public static string shoppingList = "getShoppingList?token=";
	
	public static IEnumerator fetch(string name, System.Action<ProductInfo> result) {
		WWW www = new WWW(endpoint + shoppingList + name);
		yield return www;
		
		JSONNode node = JSON.Parse(www.text);

		int status = node["status"].AsInt;
		if(status == 0) {
			JSONNode list = node["list"];
			JSONArray arr = list.AsArray;

			for(int i = 0; i < list.Count; ++i) {
				string n = list[i];

				WWW www2 = new WWW(endpoint + productName + n);
				yield return www2;
				
				JSONNode node2 = JSON.Parse(www2.text);

								
				int status2 = node2["status"].AsInt;
				if(status2 == 0) {
					JSONNode product = node2["product"];
					int id = product["id"].AsInt;
					int aisle = product["aisle"].AsInt;
					int aislePosition = product["aislePosition"].AsInt;
					
					result(new ProductInfo(name, id, aisle, aislePosition));
				}
			}
		}
	}
}
