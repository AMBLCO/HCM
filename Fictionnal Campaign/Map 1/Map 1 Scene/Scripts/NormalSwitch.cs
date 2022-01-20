﻿using UnityEngine;
 
public class NormalSwitch : MonoBehaviour {
    public Texture Normal;
	public string MaterialName;
	// Use this for initialization
	void Update () {
		Renderer[] meshRenderer = GetComponentsInChildren<Renderer>();
		if (meshRenderer.Length == 0)
		{
			return;
		}
	
        // Set the new material on the GameObject
		for (int i=0; i<meshRenderer.Length; i++)
		{
			var materials = meshRenderer[i].materials;
			for (int j = 0; j < materials.Length; j++)
			{
				if (materials[j].name.Contains(MaterialName))
				{
					materials[j].SetTexture("_BumpMap", Normal);
				}
			}
			meshRenderer[i].materials = materials;
		}
		this.enabled = false;
    }
}