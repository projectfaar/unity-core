using UnityEngine;
using System.Collections;

public class MinimapUser : MonoBehaviour {
	public Vector3 reference;

	IEnumerator Start () {
		reference = transform.position;

		if(!Input.location.isEnabledByUser) {
			Debug.LogError("Location disabled by user");
			return false;
		}

		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if (maxWait < 1) {
			Debug.LogError("Timed out");
			return false;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.LogError("Unable to determine device location");
			return false;
		} else
			Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		Input.location.Stop();

	}
	
	void Update () {

	}
}
