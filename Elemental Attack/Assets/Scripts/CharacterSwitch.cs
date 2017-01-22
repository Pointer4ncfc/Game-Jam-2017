using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour
{
    [Header("Key Codes")]
    public KeyCode fireKey;
    public KeyCode iceKey;
    public KeyCode earthKey;
    public KeyCode airKey;
    [Header("Arrays")]
    public GameObject[] states;
    public Material[] stateMats;

    [SerializeField]
    PlayerMovement player;

    Mesh mesh;
    Renderer rend;
    
    //Allows us to switch between the elements without resorting to booleans
    public enum Element { fire, ice, earth, air };
    //element is the currently selected element
    public Element element;


    void Start () {
        //Gets the mesh filter so the mesh can be changed when the models are imported
        mesh = GetComponent<MeshFilter>().mesh;
        //Gets the renderer so materials can be changed
        rend = GetComponent<Renderer>();
        //Ensures the renderer is enabled
        rend.enabled = true;

    }

    void Update() {

        //Runs the various element classes so they're not clogging the update class
        if(Input.GetKeyDown(airKey)) {
            Air();
        }
        if (Input.GetKeyDown(fireKey)) {
            Fire();
        }
        if (Input.GetKeyDown(iceKey)) {
            Ice();
        }
        if (Input.GetKeyDown(earthKey)) {
            Earth();
        }
		if(element == Element.air) {
		player.air = true;
		player.fire = false;
		player.earth = false;
		player.ice = false;

		}
		if(element == Element.fire) {
		player.air = false;
		player.fire = true;
		player.earth = false;
		player.ice = false;

		}
		if(element == Element.ice) {
		player.air = false;
		player.fire = false;
		player.earth = false;
		player.ice = true;

		}
		if(element == Element.earth) {
		player.air = false;
		player.fire = false;
		player.earth = true;
		player.ice = false;

		}
    }
    //Sets the active element for the player
    void Air() {
        element = Element.air;
        mesh = states[0].GetComponent<MeshFilter>().sharedMesh;
        rend.sharedMaterial = stateMats[0];
    }

    void Fire() {
        element = Element.fire;
        mesh = states[2].GetComponent<MeshFilter>().sharedMesh;
        rend.sharedMaterial = stateMats[2];
    }

    void Ice() {
        element = Element.ice;
        mesh = states[3].GetComponent<MeshFilter>().sharedMesh;
        rend.sharedMaterial = stateMats[3];
    }

    void Earth() {
        element = Element.earth;
        mesh = states[1].GetComponent<MeshFilter>().sharedMesh;
        rend.sharedMaterial = stateMats[1];
    }
}