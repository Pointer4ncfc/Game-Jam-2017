using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

    public float ammoSpeed;
    private Rigidbody theRB;




    // Use this for initialization
    void Start () {
        theRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
