using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapIcon : MonoBehaviour {


    public float Speed;
    public int delai;

    public Sprite[] spriteList;

    private int countFrame = 0;
    public int changeIconCount = 0;
    int indexSpriteCourant = 0;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[indexSpriteCourant];
	}
	
	// Update is called once per frame
	void Update () {
        if (Speed >= 100)
        {
            //Destroy(this.gameObject);
        }
        else if (countFrame++ % (int)Speed == 0) {
            spriteRenderer.sprite = spriteNext();
            countFrame = 1;
            changeIconCount++;
            
            if(changeIconCount >= delai)
                Speed *= 1.2f;
        }
        
	}

    private Sprite spriteNext()
    {
        if (indexSpriteCourant == spriteList.Length - 1) indexSpriteCourant = -1;
        return spriteList[++indexSpriteCourant];
    }

  

    void ChoixJeu()
    {
    }
}
