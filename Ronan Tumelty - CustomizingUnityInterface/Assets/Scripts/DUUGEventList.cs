using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DUUGEventList : ScriptableObject {
	public List<DUUGEvent> events;
	
	void OnEnable() {
		if (events == null)
			events = new List<DUUGEvent>();
	}
}
