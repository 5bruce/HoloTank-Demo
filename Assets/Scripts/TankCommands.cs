using UnityEngine;
using System.Collections;

public class TankCommands : MonoBehaviour {

    public bool isRotating = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (isRotating)
            this.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    // Called by SpeechManager when the user says the "Rotate Model" command
    void OnRotateStart()
    {
        isRotating = true;
    }

    // Called by SpeechManager when the user says the "Rotate Model" command
    void OnRotateStop()
    {
        isRotating = false;
    }

}
