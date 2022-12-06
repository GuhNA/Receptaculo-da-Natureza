using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public SpriteRenderer skin;
    public testePlayer receptaculo;
    public Elemento[] elemento = new Elemento[2];
    int i = 0;
    public bool change;

    void Start()
    {
        receptaculo.life = elemento[i].life;
        receptaculo.mana = elemento[i].mana;
        skin.color = elemento[i].color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            i = 1;
            change = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            i = 0;
            change = true;
        }

        changeElement();
    }

    void changeElement()
    {
        if(change)
        {
            receptaculo.life = elemento[i].life;
            receptaculo.mana = elemento[i].mana;
            skin.color = elemento[i].color;
            change = false;
        }
    }
}
