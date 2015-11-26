using UnityEngine;
using System.Collections;

// If run in editor, include UnityEditor
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomMonoBehaviour : MonoBehaviour {

// If run in editor, compile following
#if UNITY_EDITOR
	protected bool showDefaultInspector = true;

	// Called by CustomMonoBehaviourEditor
	public virtual void ShowInspectorGUI(Editor editor) {
		showDefaultInspector = EditorGUILayout.Toggle("Show default inspector?", showDefaultInspector);
		
		EditorGUILayout.Space();
		
		if (showDefaultInspector)
			editor.DrawDefaultInspector();
	}

	public virtual void ShowSceneGUI() {

	}

	public virtual bool HasPreviewGUI() {
		return false;
	}

	public virtual void ShowPreviewGUI(Rect r, GUIStyle background) {

	}
#endif

}
