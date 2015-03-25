using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;

public class ProductInfo {
	public string name;
	public int id, aisle, aislePosition;

	public ProductInfo(string _name, int _id, int _aisle, int _aislePosition) {
		name = _name;
		id = _id;
		aisle = _aisle;
		aislePosition = _aislePosition;
	}
}