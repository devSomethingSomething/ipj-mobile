using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);

    private void Start() => Application.targetFrameRate = 60;
}
