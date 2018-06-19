using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveDoor : MonoBehaviour {

    public DoorController door;
    public DoorController otherdoor;

    private bool state;

    private void Start()
    {
        state = door.isOpen;
    }

    void Update () {
        if (door.isOpen != state)
        {
            otherdoor.open();
            state = door.isOpen;
        }
    }
}
