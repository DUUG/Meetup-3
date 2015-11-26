using UnityEngine;
using System.Collections;

using UnityEditor;

[CustomPropertyDrawer(typeof(DUUGPresenter), true)]
public class DUUGPresenterDrawer : PropertyDrawer {
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		EditorGUI.BeginProperty(position, label, property);

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Presenter:", GUILayout.Width(65));
		EditorGUILayout.PropertyField(property.FindPropertyRelative("presenterName"), GUIContent.none);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Company:", GUILayout.Width(65));
		EditorGUILayout.PropertyField(property.FindPropertyRelative("company"), GUIContent.none);
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Length (m):", GUILayout.Width(65));
		EditorGUILayout.IntSlider(property.FindPropertyRelative("presentationLength"), 0, 45, GUIContent.none);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Title:", GUILayout.Width(65));
		EditorGUILayout.PropertyField(property.FindPropertyRelative("presentationTitle"), GUIContent.none);
		EditorGUILayout.EndHorizontal();

		EditorGUI.EndProperty();
	}
}
