using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private AudioClip welcomeAudioClip;
    [SerializeField]
    private AudioClip menuControlsAudioClip;

    private void Start()
    {
        PlayMenuAudio();
    }

    private void PlayMenuAudio()
    {
        StartCoroutine(SoundManager.Instance.Say(new AudioClip[]
        {
            welcomeAudioClip,
            menuControlsAudioClip
        }));
    }

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
