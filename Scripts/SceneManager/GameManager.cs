using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameObject player;

    [SerializeField]
    private GameObject[] players;

    private int _charIndex;    
    public int CharIndex { 
        get { return _charIndex; } 
        set { _charIndex = value; }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    public void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(scene.name == "Map1" && player == null) {
            
            player = Instantiate(players[CharIndex]);
        }
    }
}
