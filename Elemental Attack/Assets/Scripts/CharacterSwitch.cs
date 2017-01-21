using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour
{

    public bool fire;
    public bool ice;
    public bool earth;
    public bool air;


    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {



    }

    void firePressed()
    {
        if(Input.GetButtonDown("fireButton"))
        {
            fire = true;
            ice = false;
            earth = false;
            air = false;
        }
    }


}