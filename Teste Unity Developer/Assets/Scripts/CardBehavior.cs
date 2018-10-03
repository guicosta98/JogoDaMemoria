using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBehavior : MonoBehaviour {

    Image btnSprite;
    Helper helper;
    static Button btn;
    AudioSource btnSound;

    public int index = 0;
    public Sprite[] animalSprites;
    public Sprite defaultSprite;

    int spriteIndex = 0;
    bool isAvailable = false;

    /*Index:
     0 - Elephant
     1 - Giraffe
     2 - Monkey
     3 - Panda
     4 - Pig
     5 - Snake
    */

    void Start () {
        helper = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Helper>();
        btnSound = GetComponent<AudioSource>();
        btnSprite = GetComponent<Image>();
    }
	
	void Update () {
        if (!isAvailable)
        {
            spriteIndex = Random.Range(0, animalSprites.Length);
            switch (spriteIndex)
            {
                case 0:
                    if (helper.elephantCount < 2)
                    {
                        helper.elephantCount++;
                        this.gameObject.tag = "elephant";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 1:
                    if (helper.giraffeCount < 2)
                    {
                        helper.giraffeCount++;
                        this.gameObject.tag = "giraffe";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (helper.monkeyCount < 2)
                    {
                        helper.monkeyCount++;
                        this.gameObject.tag = "monkey";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    if (helper.pandaCount < 2)
                    {
                        helper.pandaCount++;
                        this.gameObject.tag = "panda";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 4:
                    if (helper.pigCount < 2)
                    {
                        helper.pigCount++;
                        this.gameObject.tag = "pig";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 5:
                    if (helper.snakeCount < 2)
                    {
                        helper.snakeCount++;
                        this.gameObject.tag = "snake";
                        isAvailable = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }
	}

    public void OnClick()
    {
        btnSprite.sprite = animalSprites[spriteIndex];
        btnSound.Play();
        if (helper.fstMove == null)
        {
            helper.fstMove = this.gameObject;
        }
        else if (helper.scdMove == null)
        {
            helper.scdMove = this.gameObject;
            helper.CheckResult();
            if (helper.rightMove)
            {
                helper.fstMove = null;
                helper.scdMove = null;
            }
            else
            {
                StartCoroutine(ExecuteAfterTime(1f));
            }
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject.Find("Card (" + i + ")").GetComponent<Button>().enabled = false;
        }
        yield return new WaitForSeconds(time);

        if (!helper.rightMove)
        {
            helper.fstMove.GetComponent<Image>().sprite = defaultSprite;
            helper.scdMove.GetComponent<Image>().sprite = defaultSprite;

            helper.fstMove = null;
            helper.scdMove = null;
        }

        for (int i = 0; i < 12; i++)
        {
            GameObject.Find("Card (" + i + ")").GetComponent<Button>().enabled = true;
        }
    }
}
