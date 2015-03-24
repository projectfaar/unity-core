using UnityEngine;
using System.Collections;

public class productSearch : MonoBehaviour {
	IEnumerator Start() {
		Debug.Log ("Search");
		CardboardGUI.onGUICallback += this.OnGUI;
		
		yield return StartCoroutine(getProductByName.fetch("potato", info => {
			Debug.Log (info.name+" is on aisle "+info.aisle);
		}));
	}

	void OnDestroy() {
		CardboardGUI.onGUICallback -= this.OnGUI;
	}
	
	void OnGUI() {
		if (!CardboardGUI.OKToDraw(this)) return;
		
		if(GUI.Button (new Rect(10, 10, 150, 100), "Cardboard Test"))
			Debug.Log ("Yay");
	}
}
