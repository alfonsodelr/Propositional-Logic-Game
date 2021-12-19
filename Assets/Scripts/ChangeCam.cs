using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera main_camera;
    public Camera this_camera;
    public Camera instruction_cam;
    // Update is called once per frame

    private void Awake() {
        main_camera.enabled = false;
            this_camera.enabled = true;
            instruction_cam.enabled = false;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            main_camera.enabled = true;
            this_camera.enabled = false;
            instruction_cam.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.I)){
            main_camera.enabled = false;
            this_camera.enabled = false;
            instruction_cam.enabled = true;
        }
    }
}
