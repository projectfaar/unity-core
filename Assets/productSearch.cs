using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	public GameObject productPrefab;
	public Vector3 mapStart, mapEnd;
	public float numAisles;

	IEnumerator Start() {
		yield return StartCoroutine(getShoppingList.fetch("0", info => {
			Debug.Log (info.name);
		}));
	}
}
