using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {


    int phase;
    public Text TextObject;
	public float timeLeft;
	public Text nbRdy;

    string[] tabJeux1 = { "OsuColor", "OsuSpown"};//{ "TapTaup" };
    string[] tabJeux2 = { "OsuColor", "OsuSpown", "Labyrinthe" };
    string[] tabJeux3 = { "OsuColor", "OsuSpown" };
    string[] tabJeux4 = { "Labyrinthe" };
    string[] tabJeux5 = { "OsuColor", "OsuSpown" };
    string[] tabJeux6 = { "Labyrinthe" };

    private void Start()
    {
        phase = 0;
    }

    void Update () {
        int tmpNbRdy = int.Parse(nbRdy.text);
        string game;
        //Phase 0 = Phase de 'log'
        if (phase == 0)
        {
            if (timeLeft <= 0.0f)
            {
                phase = 1;
                timeLeft = 10;
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
                            game = tabJeux1[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        case 2:
                            game = tabJeux2[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        case 3:
                            game = tabJeux3[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        case 4:
                            game = tabJeux4[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        case 5:
                            game = tabJeux5[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        case 6:
                            game = tabJeux6[Mathf.FloorToInt(Random.Range(0, tabJeux4.Length))];
                            LaunchGame(game);
                            phase = 2;
                            break;
                        default:
                            break;
                    }
                    //Choix Final

                }
                else
                {
                    //AnimChoix
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
		
        
	}

	void LaunchGame(string game) {
        SceneManager.LoadScene(game);
        //SceneManager.LoadScene ("TapTaupMain");
        print(game);
	}
}
