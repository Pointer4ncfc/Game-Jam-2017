using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform Capsule1;
    public Transform Capsule2;
    public Vector3 center;

    void Update() {
        center = ((Capsule2.position - Capsule1.position) / 2.0f) + Capsule1.position;
       // transform.LookAt(center);
        transform.position = new Vector3(center.x-50,center.y+54,-70);

    }
}