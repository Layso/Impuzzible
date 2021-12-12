using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Triangle : MonoBehaviour {
	int[] triangles;
	Vector3[] vertices;
	MeshFilter meshFilter;

	void Awake() {
		meshFilter = GetComponent<MeshFilter>();
		Vector3 right = Quaternion.Euler(0, 30, 0) * new Vector3(0, 0, 2);
		Vector3 left = Quaternion.Euler(0, -30, 0) * new Vector3(0, 0, 2);

		vertices = new Vector3[] {
			new Vector3(0,0,0),
			right,
			left,
		};

		triangles = new int[] {
			0,2,1
		};

		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		meshFilter.mesh = mesh;
		meshFilter.mesh.RecalculateNormals();
	
		MeshCollider collider = gameObject.AddComponent<MeshCollider>();
		collider.sharedMesh = meshFilter.mesh;
	}

	public void ApplyMaterial(Material mat) {
		GetComponent<MeshRenderer>().material = mat;
	}
}
