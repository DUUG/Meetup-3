using UnityEngine;
using UnityEditor;
using System.Collections;

// Instructs engine to use this class over default inspector
[CustomEditor(typeof(CustomMonoBehaviour), true)]
// Allows the editing of multiple instances of an object at once
[CanEditMultipleObjects]
public class CustomMonoBehaviourInspector : Editor {
	
	public override void OnInspectorGUI() {
		CustomMonoBehaviour customBehaviour = target as CustomMonoBehaviour;
		customBehaviour.ShowInspectorGUI(this);
	}
	
	public virtual void OnSceneGUI() {
		CustomMonoBehaviour customBehaviour = target as CustomMonoBehaviour;
		customBehaviour.ShowSceneGUI();
	}
	
	public override bool HasPreviewGUI() {
		CustomMonoBehaviour customBehaviour = target as CustomMonoBehaviour;
		return customBehaviour.HasPreviewGUI();
	}
	
	public override void OnPreviewGUI(Rect r, GUIStyle background) {
		CustomMonoBehaviour customBehaviour = target as CustomMonoBehaviour;
		customBehaviour.ShowPreviewGUI(r, background);
	}
}
