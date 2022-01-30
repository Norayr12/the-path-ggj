using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    [SerializeField] private SceneBase[] _scenes;

    [SerializeField] private GameObject _endingScene;

    private int _currentScene = 0;

    private void Awake()
    {
        if (Instance is null)
            Instance = this;

        _scenes[_currentScene].Initialize();
    }

    public void NextLevel()
    {
       ++_currentScene;
       _scenes[_currentScene].Initialize();                
    }

    public bool CheckIfLast() => _currentScene == _scenes.Length - 1;

    public void StartEndScene()
    {
        for (int i = 0; i < _scenes.Length; i++)
        {
            _scenes[i].gameObject.SetActive(false);
        }

        _endingScene.SetActive(true);
        StartCoroutine(_endingScene.GetComponent<EndScene>().StartScene());
    }
    
}
