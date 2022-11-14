using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Update()
    {
        MenuOptionSelected(KeyCode.T, "TutorialScene");
        MenuOptionSelected(KeyCode.D, "DemoScene");
        ExitSelected();
    }

    private void MenuOptionSelected(KeyCode keyCode, string sceneName)
    {
        if (Input.GetKeyDown(keyCode))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void ExitSelected()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
