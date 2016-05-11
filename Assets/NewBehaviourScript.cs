using UnityEngine;
using System.Collections;
using System;
using KiiCorp.Cloud.Unity;
using KiiCorp.Cloud.Storage;

public class NewBehaviourScript : KiiInitializeBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    string message = "hello.";
    void OnGUI() {
        GUI.Label (new Rect (25, 25, 150, 30), message);
        if (GUI.Button (new Rect (25, 25+50, 150, 30), "My")) {
            message = "Login to cloud...";

            KiiUser.LogIn("pass-1234","1234",(KiiUser user, Exception e) => {
                if (e != null) {
                    message = e.Message;
                    return;
                }
                message = "Login Success! id:" + user.ID;
            });
        }
    }

}
