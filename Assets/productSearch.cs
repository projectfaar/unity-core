using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	IEnumerator Start() {
		Debug.Log ("Search");
		yield return StartCoroutine(getProductByName.fetch());
	}
}
