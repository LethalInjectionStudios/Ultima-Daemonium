using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string sceneToOpen;

    public void Interact()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
