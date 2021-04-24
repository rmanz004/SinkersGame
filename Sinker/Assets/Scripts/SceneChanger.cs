using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

	[SerializeField] private GameObject MainPage;
	[SerializeField] private GameObject RulesPage;

	public void ShowRules() {
		MainPage.SetActive(false);
		RulesPage.SetActive(true);
	}

	public void HideRules() {
		MainPage.SetActive(true);
		RulesPage.SetActive(false);
	}

	public void LoadScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void exitgame() {  
        Debug.Log("exitgame");  
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();  
    } 
}
