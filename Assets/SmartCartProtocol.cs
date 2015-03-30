using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class SmartCartProtocol : MonoBehaviour {
	TcpClient client;
	Stream s;
	StreamReader reader;
	StreamWriter writer;

	// Use this for initialization
	void Start () {
		client = new TcpClient("127.0.0.1", 7070);

		s = client.GetStream();
		reader = new StreamReader(s);
		writer = new StreamWriter(s);
		writer.AutoFlush = true;

		Authenticate ("DEADBEEF");
	}

	void Authenticate(string cartIdentifier) {
		writer.WriteLine(cartIdentifier+",0");
	}

	void Update() {
		if(client.Available > 0) {
			string si = reader.ReadLine();
			string[] parts = si.Split(',');

			if(parts[0] == "0") {
				string item = parts[1];
				Debug.Log ("Retrieved item "+item);

				if(!productSearch.blips.ContainsKey(item)) {
					Debug.Log ("You weren't supposed to buy "+item+"!");
					return;
				}

				Destroy (productSearch.blips[item]);
			
				productSearch.blips.Remove(item);
			}
		}
	}

}
