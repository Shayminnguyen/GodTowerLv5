using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    private static string LEVEL_TEXT = "LEVEL";
    private static string ACCESS_DENIED_TEXT = "ACCESS DENIED!";
    private static float NAME_CHANGE_INTERVAL = 1;

    public string password;
    public string levelName;
    public string levelHintText;
    public string nextLevelSceneFilename;

    public InputField passwordInput;
    public Text hintTextField;
    public Text levelNameTextField;
    public Button nextHintButton;
    public List<GameObject> levelHintList;

    private float nextLevelNameChangeTimestamp = NAME_CHANGE_INTERVAL;
    private Coroutine hintTextCoroutine;
    private int currentHintIndex = 0;

    // Start() is called immediately when this component appears on screen
    private void Start()
    {
        hintTextField.text = levelHintText;

        if (levelHintList.Count > 1) {
            nextHintButton.gameObject.SetActive(true);
            DisplayCurrentHint();
        }
    }

    // Update() is called continuously throughout the lifespan of this component, before each screen render
    private void Update()
    {
        if(Time.timeSinceLevelLoad > nextLevelNameChangeTimestamp) {
            nextLevelNameChangeTimestamp += NAME_CHANGE_INTERVAL;
            levelNameTextField.text = (levelNameTextField.text == LEVEL_TEXT) ? levelName : LEVEL_TEXT;
        }
    }

    public void OnNextHintButtonClicked() {
        currentHintIndex++;
        currentHintIndex %= levelHintList.Count;
        if (currentHintIndex == levelHintList.Count - 1)
        {
            nextHintButton.transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            nextHintButton.transform.localScale = Vector3.one;
        }
        DisplayCurrentHint();
    }

    private void DisplayCurrentHint() {
        for (int i = 0; i < levelHintList.Count; i++)
        {
            levelHintList[i].SetActive(i == currentHintIndex);
        }
    }

    public void OnSubmitButtonClicked() {
        if (passwordInput.text == password)
        {
            TKSceneManager.ChangeScene(nextLevelSceneFilename);
        }
        else {
            passwordInput.text = "";
            hintTextField.text = ACCESS_DENIED_TEXT;
            hintTextField.color = Color.red;

            if (hintTextCoroutine != null) {
                StopCoroutine(hintTextCoroutine);
            }
            hintTextCoroutine = StartCoroutine(ChangeHintTextBack());
        }
    }

    private IEnumerator ChangeHintTextBack() {
        yield return new WaitForSeconds(2);
        hintTextField.text = levelHintText;
        hintTextField.color = Color.black;
    }
}
