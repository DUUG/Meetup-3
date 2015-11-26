using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(MeshRenderer))]
public class PreviewExample : CustomMonoBehaviour {
	enum PreviewType {
		Cube,
		Sphere,
		Capsule
	}

	[SerializeField] Mesh[] meshes;
	[SerializeField] PreviewType previewType;
	[SerializeField] Vector3 cameraPosition = new Vector3(0, 0, -6);

	private PreviewRenderUtility previewRenderUtility;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;

#if UNITY_EDITOR
	void SetupPreview() {
		if (previewRenderUtility == null) {
			previewRenderUtility = new PreviewRenderUtility();

			previewRenderUtility.m_Camera.transform.position = cameraPosition;
			previewRenderUtility.m_Camera.transform.rotation = Quaternion.identity;
		}
		
		if (meshFilter == null)
			meshFilter = GetComponent<MeshFilter>();
		
		if (meshRenderer == null)
			meshRenderer = GetComponent<MeshRenderer>();
	}

	public override bool HasPreviewGUI() {
		SetupPreview();

		if (meshes.Length >= 3)
			return true;
		else
			return false;
	}

	public override void ShowPreviewGUI(Rect r, GUIStyle background) {
		switch (previewType) {
		case PreviewType.Cube:
			meshFilter.mesh = meshes[0];
			break;
		case PreviewType.Sphere:
			meshFilter.mesh = meshes[1];
			break;
		case PreviewType.Capsule:
			meshFilter.mesh = meshes[2];
			break;
		}

		if (Event.current.type == EventType.Repaint) {

			previewRenderUtility.BeginPreview(r, background);
			
			previewRenderUtility.DrawMesh(meshFilter.sharedMesh, Matrix4x4.identity, meshRenderer.sharedMaterial, 0);
			previewRenderUtility.m_Camera.transform.position = cameraPosition;
			previewRenderUtility.m_Camera.Render();

			Texture renderedPreview = previewRenderUtility.EndPreview();
			GUI.DrawTexture(r, renderedPreview, ScaleMode.StretchToFill, false);
		}
	}
#endif

}
