using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	public GameObject productPrefab;
	public Vector3 mapStart, mapEnd;
	public float numAisles;

	IEnumerator Start() {
		Debug.Log ("Search");

		yield return StartCoroutine(getProductByName.fetch("potato", info => {
			if(info != null) {
				Debug.Log (info.name+" is on aisle "+info.aisle);
				Debug.Log (mapEnd.x - mapStart.x);
				Debug.Log ( (info.aisle - 1) / numAisles);
				
				Instantiate (productPrefab, new Vector3(mapStart.x + (
						(mapEnd.x - mapStart.x) * ((info.aisle - 1) / numAisles)
					), 
				                                        mapStart.y + ((info.aislePosition / 256f) * (mapEnd.y - mapStart.y)), mapStart.z),
				             							Quaternion.identity);
			}
		}));
	}
	
}
