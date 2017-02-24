using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

    public void OnBeginButtonClicked() {
        TKSceneManager.ChangeScene("Level1");
    }

    public void OnContinueButtonClicked() {
        // TODO: continue function here
    }
}
