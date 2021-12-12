using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hexagon : MonoBehaviour {
	[SerializeField] private GameObject Triangle;
	[SerializeField] private Material[] Materials;

	private bool bIsPlaced;

	void Start() {
		for (int i=0; i<6; ++i) {
			var tri = GameObject.Instantiate(Triangle, transform.localPosition, Quaternion.identity, transform);
			tri.GetComponent<Triangle>().ApplyMaterial(Materials[Mathf.Min(Materials.Length-1,i)]);
			tri.transform.RotateAround(transform.localPosition, Vector3.up, 60*i);
		}
	}

	public void CheckPlaceholder() {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.parent.tag == "Finish") {
			Vector3 hitPos = hit.transform.parent.position;
			transform.position = new Vector3(hitPos.x, 0, hitPos.z);
			bIsPlaced = true;
		} else {
			bIsPlaced = false;
		}
	}

	public bool IsPlaced() {
		return bIsPlaced;
	}
}
