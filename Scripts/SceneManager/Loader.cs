using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Loader : MonoBehaviour
{
    private Vector3 spawnPosition;

    public void SelectingPlayer()
    {
        string clickedButton = EventSystem.current.currentSelectedGameObject.name;
        int selectedPlayer = int.Parse(clickedButton);

        GameManager.instance.CharIndex = 0;

        SceneManager.LoadScene("Map1");
        GameManager.player.transform.position = Vector3.zero; 
    }

    public void SelectingDifficulty()
    {   
        string clickedButton = EventSystem.current.currentSelectedGameObject.name;
        int selectedDifficulty = int.Parse(clickedButton);

        if (selectedDifficulty == 1) {
            EnemyStatistic.hardness = 2f;
        } else {
            EnemyStatistic.hardness = 0f;
        }
    }
}
