using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DUUGEventManager : EditorWindow {
	static DUUGEventList eventList;
	static string path = "Assets/EventList.asset";
	static Vector2 scrollPosition = Vector2.zero;
	static GUISkin exampleSkin;

	[MenuItem("DUUG/Event Manager")]
	public static void ShowWindow() {
		eventList = AssetDatabase.LoadAssetAtPath(path, typeof(DUUGEventList)) as DUUGEventList;
		exampleSkin = Resources.LoadAssetAtPath("Assets/Example Skin.guiskin", typeof(GUISkin)) as GUISkin;
		EditorWindow.GetWindow(typeof(DUUGEventManager));
	}

	void OnGUI() {
		GUI.skin = exampleSkin;

		if (eventList == null) 
		{
			GUILayout.Label("Select EventList asset in Project view, or create a new EventList", EditorStyles.wordWrappedLabel);
			path = EditorGUILayout.TextField("File path:", path, GUILayout.ExpandWidth(true));
			if (path == "") {
				EditorGUILayout.HelpBox("File path required to create new asset", MessageType.Warning);
			}

			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Open Selected List")) {
				eventList = Selection.activeObject as DUUGEventList;
			}
			if (GUILayout.Button("Create New List") && path != "") {
				eventList = ScriptableObject.CreateInstance<DUUGEventList>();
				AssetDatabase.CreateAsset(eventList as Object, path + ".asset");
				Debug.Log(AssetDatabase.GetAssetPath(eventList));
			}
			EditorGUILayout.EndHorizontal();
		}
		else {
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Save Current List")) {
				EditorUtility.SetDirty(eventList);
				AssetDatabase.SaveAssets();
			}
			if (GUILayout.Button("Open Selected List")) {
				eventList = Selection.activeObject as DUUGEventList;
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.Space();
			GUILayout.TextField("Events:", EditorStyles.boldLabel);

			scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
			for (int i = 0; i < eventList.events.Count; i++) {
				DUUGEvent duugEvent = eventList.events[i];
				SerializedObject serializedEvent = new SerializedObject(duugEvent);

				EditorGUILayout.BeginVertical(EditorStyles.textArea);
				duugEvent.expand = EditorGUILayout.Foldout(duugEvent.expand, "Event " + (i+1) + ":");

				if (duugEvent.expand) {
					duugEvent.venue = EditorGUILayout.TextField("Venue:", duugEvent.venue);
					
					EditorGUILayout.BeginHorizontal();
					GUILayout.Label("Date:", GUILayout.Width(60));
					EditorGUILayout.Space();
					duugEvent.day = EditorGUILayout.IntField(duugEvent.day, GUILayout.Width(20));
					duugEvent.month = EditorGUILayout.IntField(duugEvent.month, GUILayout.Width(20));
					duugEvent.year = EditorGUILayout.IntField(duugEvent.year, GUILayout.Width(40));
					EditorGUILayout.EndHorizontal();

					EditorGUILayout.Space();
					
					SerializedProperty presenterProperty = serializedEvent.FindProperty("presenters");
					int presenterCount = presenterProperty.arraySize;

					presenterProperty.Next(true);
					presenterProperty.Next(true);
					
					GUILayout.Label("Presenters:");
					if (GUILayout.Button("Add presenter")) {
						duugEvent.presenters.Add(new DUUGPresenter());
					}

					for (int j = 0; j < presenterCount; j++) {
						presenterProperty.Next(false);
						EditorGUILayout.PropertyField(presenterProperty);
						if (GUILayout.Button("Remove presenter")) {
							duugEvent.presenters.Remove(duugEvent.presenters[i]);
							break;
						}
					}
					presenterProperty.serializedObject.ApplyModifiedProperties();
				}

				if (GUILayout.Button("Delete event")) {
					eventList.events.Remove(eventList.events[i]);
					break;
				}

				EditorGUILayout.Space();
				EditorGUILayout.EndVertical();
			}
			EditorGUILayout.EndScrollView();

			if (GUILayout.Button("Add Event")) {
				eventList.events.Add(ScriptableObject.CreateInstance<DUUGEvent>());
			}
		}
	}

}
