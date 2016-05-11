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
    string username = "";
    string password = "";
    void OnGUI() {
        GUI.Label (new Rect (25, 25, 150, 50), message);
        username = GUI.TextField(new Rect(25, 100, 150, 50), username);
        password = GUI.PasswordField(new Rect(25, 175, 150, 50), password, '*');

        if (GUI.Button (new Rect (25, 250, 150, 50), "Login")) {
            message = "Login to cloud...";

            KiiUser.LogIn(username, password,(KiiUser user, Exception e) => {
                if (e != null) {
                    message = e.Message;
                    return;
                }
                message = "Login Success! id:" + user.ID;
            });
        }

        if (GUI.Button(new Rect(25, 325, 150, 50), "Object"))
        {
            message = "Create object in Cloud...";
            KiiObject obj = Kii.Bucket("TestBucket").NewKiiObject();
            obj.Save((KiiObject obj2, Exception e2) =>
            {
                if (e2 != null)
                {
                    message = e2.Message;
                    return;
                }
                message = "Save Object has been succeeded! id:" + obj2.Uri;
            });
        }
    }

}
