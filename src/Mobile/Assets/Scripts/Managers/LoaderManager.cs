using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
    private void Start() => SceneManager.LoadScene("MenuScene");
}
