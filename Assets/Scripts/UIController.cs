using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button retryButton;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(RetryScene);
    }

    void RetryScene(){
        // Get actual scene
        int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
		// Reload actual scene
		SceneManager.LoadScene(actualSceneIndex);
    }
}
