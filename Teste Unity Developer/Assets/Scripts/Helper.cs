using UnityEngine;
using UnityEngine.UI;


public class Helper : MonoBehaviour {
    
    public int giraffeCount = 0;
    public int elephantCount = 0;
    public int pigCount = 0;
    public int pandaCount = 0;
    public int monkeyCount = 0;
    public int snakeCount = 0;
    public int tries = 0;
    public int matchedAnimals = 0;
    public int score = 0;

    public bool rightMove = false;

    public GameObject fstMove = null;
    public GameObject scdMove = null;
    public Text triesText;
    public Text scoreText;
    public AudioSource matchSound;


    public void CheckResult()
    {
        if(fstMove != null && scdMove != null)
        {
            if(fstMove.tag == scdMove.tag)
            {
                tries++;
                matchedAnimals++;
                rightMove = true;
                matchSound.Play();
            }
            else
            {
                tries++;
                rightMove = false;
            }
            triesText.text = ""+tries;
        }

        if(matchedAnimals == 6)
        {
            score = 6000 / tries;
            scoreText.text = score.ToString();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuButtons>().OnGameOver();
        }
    }
}
