using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	public GameObject productPrefab;
	public Vector3 mapStart, mapEnd;

	IEnumerator Start() {
		Debug.Log ("Search");

		yield return StartCoroutine(getProductByName.fetch("potato", info => {
			if(info != null) {
				Debug.Log (info.name+" is on aisle "+info.aisle);
				Instantiate (productPrefab, new Vector3(mapStart.x, mapStart.y, mapStart.z), Quaternion.identity);
			}
		}));
	}
	
}
