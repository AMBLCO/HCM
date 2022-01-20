using UnityEngine;

public class AlbedoSwitch : MonoBehaviour
{
	public Texture Albedo;
	public string MaterialName;
	public Vector2 Tiling = Vector2.one;
	public Vector2 Offset = Vector2.one;
	// Use this for initialization
	void Update()
	{
		Renderer[] meshRenderer = GetComponentsInChildren<Renderer>();
		if (meshRenderer.Length == 0)
		{
			return;
		}

		// Set the new material on the GameObject
		for (int i = 0; i < meshRenderer.Length; i++)
		{
			var materials = meshRenderer[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				if (materials[j].name.Contains(MaterialName))
				{
					materials[j].SetTexture("_MainTex", Albedo);
					materials[j].mainTextureScale = Tiling;
					materials[j].mainTextureOffset = Offset;
				}
			}
			meshRenderer[i].materials = materials;
		}
		this.enabled = false;
	}
}