using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections; 
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private string[] _sceneTitles;

    private const float initial_delay = 3f;

    public void LoadScene(int sceneIndex) => StartCoroutine(LoadSceneCoroutine(sceneIndex));

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        int _sceneTitleIndex = Random.Range(0, _sceneTitles.Length);
        _titleText.text = $"{_sceneTitles[_sceneTitleIndex]}...";
        _progressText.text = $"Loading: {_sceneTitleIndex * 10}%";

        yield return new WaitForSeconds(initial_delay);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            _progressText.text = $"Loading {progress * 100f}%";

            yield return null;
        }
    }
}




