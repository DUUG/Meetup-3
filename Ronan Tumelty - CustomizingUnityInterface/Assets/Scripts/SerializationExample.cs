using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SerializationExample : CustomMonoBehaviour {
	
	private string nonSerialized = "Non-serialized private string";
	public string publicString = "Public string";
	[SerializeField]
	private string serializedString = "Serialized private string";

#if UNITY_EDITOR
	public override void ShowInspectorGUI(Editor editor) {
		GUILayout.Label("Default inspector:", EditorStyles.boldLabel);
		editor.DrawDefaultInspector();

		EditorGUILayout.Space();

		GUILayout.Label("Custom inspector:", EditorStyles.boldLabel);

		GUILayout.Label("Custom inspectors can expose otherwise inaccessible private variables", EditorStyles.wordWrappedLabel);
		nonSerialized = EditorGUILayout.TextField("Like this: ", nonSerialized);
	}
#endif
}
