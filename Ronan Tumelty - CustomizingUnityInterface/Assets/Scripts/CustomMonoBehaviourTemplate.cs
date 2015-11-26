// Template for child classes of CustomMonoBehaviour. 

using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomMonoBehaviourTemplate : CustomMonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

#if UNITY_EDITOR
	public override void ShowInspectorGUI(Editor editor) {
		// Calls inspector code from parent class (in this case, allows user to display the default inspector for the object)
		base.ShowInspectorGUI(editor);

		// Insert inspector code here
	}
#endif
}
