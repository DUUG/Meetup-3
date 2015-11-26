using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class HandlesExample : CustomMonoBehaviour {
	[SerializeField] Vector3 handlePosition = new Vector3(1, 1, 0);
	[SerializeField] Quaternion handleRotation = Quaternion.identity;

#if UNITY_EDITOR
	public override void ShowSceneGUI() {
		Handles.Label(handlePosition, "Handle example");
		handlePosition = Handles.PositionHandle(handlePosition, handleRotation);
		handleRotation = Handles.Disc(handleRotation, handlePosition, new Vector3(1, 1, 0), 1, false, 0);
	}
#endif
}
