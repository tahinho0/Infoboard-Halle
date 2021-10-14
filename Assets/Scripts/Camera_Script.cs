using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Script : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var script = GetComponent<Hinze_NewScript>();
        if (Physics.Raycast(ray, out hit, 27f))
        {
            var selection = hit.transform;
            script.showInfo(selection.name);
        }
        else
        {
            script.hideInfoBox();
        }
    }
}