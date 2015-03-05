using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	IEnumerator Start() {
		Debug.Log ("Search");

		yield return StartCoroutine(getProductByName.fetch("potato", info => {
			Debug.Log (info.name+" is on aisle "+info.aisle);
		}));

	}
}
