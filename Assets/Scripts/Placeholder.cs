using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour {
	[SerializeField] private Material Material;
	[SerializeField] private GameObject Triangle;

	void Start() {
		for (int i = 0; i < 6; ++i) {
			var tri = GameObject.Instantiate(Triangle, transform.localPosition, Quaternion.identity, transform);
			tri.GetComponent<Triangle>().ApplyMaterial(Material);
			tri.transform.RotateAround(transform.localPosition, Vector3.up, 60 * i);
		}
	}
}
