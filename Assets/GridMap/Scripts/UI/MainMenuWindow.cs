using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake() {
        transform.Find("loadBtn").GetComponent<Button_UI>().ClickFunc = () => {
            Blueprint.LoadDialog();
        };
        transform.Find("quitBtn").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
    }
}
