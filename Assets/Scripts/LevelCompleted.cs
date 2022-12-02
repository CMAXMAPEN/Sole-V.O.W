using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public GameObject levelCompletedText;
    public GameController gameController;

    private void Start()
    {
        // gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelCompletedText.SetActive(true);
            gameController.SetLevelCompleted();
            Destroy(other);
        }
    }
}
