using UnityEngine;

public class TextureSwitch : MonoBehaviour
{
	public Texture Albedo;
	public Texture Roughness;
	public Texture Normal;
	public Texture Depth;
	public Texture AO;
	public Color Tint;
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
					materials[j].SetTexture("_SpecGlossMap", Roughness);
					materials[j].SetTexture("_BumpMap", Normal);
					materials[j].SetTexture("_ParallaxMap", Depth);
					materials[j].SetTexture("_OcclusionMap", AO);
					materials[j].mainTextureScale = Tiling;
					materials[j].mainTextureOffset = Offset;
					materials[j].color = Tint;
				}
			}
			meshRenderer[i].materials = materials;
		}
		this.enabled = false;
	}
}