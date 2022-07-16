using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2Map1 : Collidable
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Vector3 spawnPosition;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Swordsman(Clone)") {
            DontDestroyOnLoad(GameManager.player);           
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            GameManager.player.transform.position = spawnPosition; 
        }
    }
}
