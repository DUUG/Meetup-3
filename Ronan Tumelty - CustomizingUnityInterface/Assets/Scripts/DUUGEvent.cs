using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class DUUGEvent : ScriptableObject {
	public string venue;
	public int day;
	public int month;
	public int year;

	public List<DUUGPresenter> presenters;

#if UNITY_EDITOR
	public bool expand;
#endif

	void OnEnable() {
		if (presenters == null)
			presenters = new List<DUUGPresenter>();
	}
}
