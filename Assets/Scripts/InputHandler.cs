using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
	[SerializeField] private float RotateDoubleClickThreshold;
	private Hexagon Hexagon;
	private float LastClickTime;


	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			OnPointerDown();
		}

		if (Input.GetMouseButton(0)) {
			OnPointerDrag();
		}

		if (Input.GetMouseButtonUp(0)) {
			OnPointerUp();
		}

		/*
		RaycastHit hit;
		float distance = 0;
		Hexagon hexagon = null;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100.0f)) {
			if (hexagon = hit.transform.parent.GetComponent<Hexagon>()) {
				distance = hit.distance;
			}
		}

		if (Input.GetMouseButtonDown(0) && hexagon) {
			if (Time.time - LastClickTime < RotateDoubleClickThreshold) {
				hexagon.transform.RotateAround(hexagon.transform.position, Vector3.up, 60);
			}

			LastClickTime = Time.time;
		}

		if (Input.GetMouseButton(0) && hexagon && (!hexagon.IsPlaced() || Time.time - LastClickTime > RotateDoubleClickThreshold)) {
			Vector3 mousePos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));
			worldPos.y = 0;

			hexagon.transform.position = worldPos;
		}

		if (Input.GetMouseButtonUp(0) && hexagon) {
			hexagon.GetComponent<Hexagon>().CheckPlaceholder();
		}
		*/
	}

	private void OnPointerDown() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100.0f)) {
			Hexagon = hit.transform.parent.GetComponent<Hexagon>();
		}

		if (Time.time - LastClickTime < RotateDoubleClickThreshold) {
			Hexagon.transform.RotateAround(Hexagon.transform.position, Vector3.up, 60);
		}

		LastClickTime = Time.time;
	}

	private void OnPointerDrag() {
		if (Hexagon && (!Hexagon.IsPlaced() || Time.time - LastClickTime > RotateDoubleClickThreshold)) {
			Vector3 mousePos = Input.mousePosition;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
			worldPos.y = 0;

			Hexagon.transform.position = worldPos;
		}
	}

	private void OnPointerUp() {
		Hexagon.CheckPlaceholder();
		Hexagon = null;
	}
}
