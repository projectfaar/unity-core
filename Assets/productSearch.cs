using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class productSearch : MonoBehaviour {
	public GameObject productPrefab;
	public Vector3 mapStart, mapEnd;
	public float numAisles;

	public string listNum = "0";
	public bool tokenInput = true;
	public bool updating = false;

	public static Dictionary<string, GameObject> blips;
	
	public Cardboard cardboard;

	void Start() {
		cardboard.VRModeEnabled = false;
		OnClick (); // TODO: Proper GUI
	}
	
	public void OnValueChange(string s) {
		listNum = s;
	}

	public void OnClick() {
		tokenInput = false;	
		cardboard.VRModeEnabled = true;

		StartCoroutine(getShoppingList.fetch(listNum, info => {
			GameObject go = Instantiate (productPrefab, new Vector3(mapStart.x + (
				(mapEnd.x - mapStart.x) * ((info.aisle - 1) / numAisles)
				), 
			                                        mapStart.y + ((info.aislePosition / 256f) * (mapEnd.y - mapStart.y)), mapStart.z),
			             Quaternion.identity) as GameObject;

			go.tag = info.name;
			blips[info.name] = go;
		}));
	}
}
