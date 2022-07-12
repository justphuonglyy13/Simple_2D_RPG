using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Loader : MonoBehaviour
{
    public void SelectingPlayer()
    {
        string clickedButton = EventSystem.current.currentSelectedGameObject.name;
        int selectedPlayer = int.Parse(clickedButton);

        GameManager.instance.CharIndex = 0;

        SceneManager.LoadScene("Map1");
    }

    public void SelectingDifficulty()
    {   
        string clickedButton = EventSystem.current.currentSelectedGameObject.name;
        int selectedDifficulty = int.Parse(clickedButton);

        SceneManager.LoadScene("Map1");
    }

    public void ChangingBetweenMaps() {
        
    }
}
