using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour
{

    public KeyCode fireKey;
    public KeyCode iceKey;
    public KeyCode earthKey;
    public KeyCode airKey;

    public GameObject[] states;
    public Material[] stateMats;

    [SerializeField]
    PlayerMovement player;

    Mesh mesh;
    Renderer rend;

    enum Element { fire, ice, earth, air };
    Element element;


    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update() {


        if(Input.GetKeyDown(airKey)) {
            Air();
            Debug.Log("Air!");
            mesh = states[0].GetComponent<MeshFilter>().sharedMesh;
            rend.sharedMaterial = stateMats[0];
        }
        if (Input.GetKeyDown(fireKey)) {
            Fire();
            Debug.Log("Fire!");
            mesh = states[2].GetComponent<MeshFilter>().sharedMesh;
            rend.sharedMaterial = stateMats[2];
        }
        if (Input.GetKeyDown(iceKey)) {
            Ice();
            Debug.Log("Ice!");
            mesh = states[3].GetComponent<MeshFilter>().sharedMesh;
            rend.sharedMaterial = stateMats[3];
        }
        if (Input.GetKeyDown(earthKey)) {
            Earth();
            Debug.Log("Earth!");
            mesh = states[1].GetComponent<MeshFilter>().sharedMesh;
            rend.sharedMaterial = stateMats[1];
        }



    }

    void Fire() {
        element = Element.fire;
    }

    void Ice() {
        element = Element.ice;
    }

    void Earth() {
        element = Element.earth;
    }

    void Air() {
        element = Element.air;
    }
}