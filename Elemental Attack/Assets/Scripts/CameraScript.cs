using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform Capsule1;
    public Transform Capsule2;
    public Vector3 center;

	PlayerMovement p1;
	PlayerMovement p2;

	

    void Update() {
		if (Capsule1 && Capsule2) {
			center = ((Capsule2.position - Capsule1.position) / 2.0f) + Capsule1.position;
			// transform.LookAt(center);
			transform.position = new Vector3(center.x - 50, center.y + 54, -70);
		} else {
			transform.position = new Vector3(-39.7f, 54.1f, -55.01f);
		}

    }
}