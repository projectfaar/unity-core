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
			Debug.Log (si);
		}
	}

}
