using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class timer : MonoBehaviour {
    
    public Text TextObject;
	public float timeLeft;
	public Text nbRdy;

    string[] tabJeux1 = { "OSU", "Lights", "Taupe" };
    string[] tabJeux2 = { "OSU", "Lights", "Labyrinthe", "Taupe" };
    string[] tabJeux3 = { "OSU", "Lights", "Taupe" };
    string[] tabJeux4 = { "OSU", "Lights", "Labyrinthe", "Taupe" };
    string[] tabJeux5 = { "OSU", "Lights", "Taupe" };
    string[] tabJeux6 = { "OSU", "Lights", "Labyrinthe", "Taupe" };

    public GameObject[] IconeList;
    public Sprite[] SpriteList;

    int phase;
    string game;

    private void Start()
    {
        game = "";
        for (int i = 0; i < IconeList.Length; i++)
        {
            IconeList[i].SetActive(false);
        }
        phase = 0;
    }

    void Update () {
        int tmpNbRdy = int.Parse(nbRdy.text);
        

        //Phase 0 = Phase de 'log'
        if (phase == 0)
        {
            if (timeLeft <= 0.0f)
            {
                phase = 1;
                timeLeft = 10;
                //Start AnimChoix
                for (int i = 0; i < IconeList.Length; i++)
                {
                    IconeList[i].SetActive(true);
                }
            }
            else
            {
                timeLeft = timeLeft - Time.deltaTime;
                int tmpTimeLeft = (int)timeLeft;
                TextObject.text = tmpTimeLeft.ToString();
            }
        }

        //Phase 1 = Décompte jeu
        if(phase == 1)
        {
            if (tmpNbRdy > 0)
            {
                if (timeLeft < 0.0f)
                {
                    switch (tmpNbRdy)
                    {
                        case 1:
                            game = tabJeux1[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        case 2:
                            game = tabJeux2[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        case 3:
                            game = tabJeux3[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        case 4:
                            game = tabJeux4[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        case 5:
                            game = tabJeux5[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        case 6:
                            game = tabJeux6[Mathf.FloorToInt(UnityEngine.Random.Range(0, tabJeux4.Length))];
                            timeLeft = 2;
                            //LaunchGame(game);
                            phase = 2;
                            break;
                        default:
                            break;
                    }
                    //Choix Final

                }
                else
                {
                    timeLeft = timeLeft - Time.deltaTime;
                    int tmpTimeLeft = (int)timeLeft;
                    TextObject.text = tmpTimeLeft.ToString();
                }
            }
            else
            {
                phase = 0;
                timeLeft = 20;
            }
        }

        //Phase 2 = Lancement jeu
        if(phase == 2)
        {
            LaunchGame(game);
        }
		
        
	}

	void LaunchGame(string game) {
        for(int i = 0; i < IconeList.Length; i++)
        {
            IconeList[i].GetComponent<SwapIcon>().Speed = 100;
            IconeList[i].GetComponent<SpriteRenderer>().sprite = Array.Find(SpriteList, s => s.name == "Icone_" + game);
        }
        if (timeLeft <= 0.0f)
        {
            SceneManager.LoadScene(game);
            //SceneManager.LoadScene ("TapTaupMain");
            print(game);
        }
        else
        {
            timeLeft = timeLeft - Time.deltaTime;
            int tmpTimeLeft = (int)timeLeft;
            TextObject.text = tmpTimeLeft.ToString();
        }
        
	}
}
