using UnityEngine;

public class MeshSwitch : MonoBehaviour
{
	public Mesh Mesh;
	public string MeshName;
	void Update()
	{
		MeshFilter[] meshes = GetComponentsInChildren<MeshFilter>();
		if (meshes.Length == 0)
		{
			return;
		}

		for (int i = 0; i < meshes.Length; i++)
		{
			Mesh mesh = meshes[i].mesh;
			{
				if (mesh.name.Contains(MeshName)) 
				{
					mesh = (Mesh);
				}
			}
			meshes[i].mesh = mesh;
		}
		this.enabled = false;
	}
}