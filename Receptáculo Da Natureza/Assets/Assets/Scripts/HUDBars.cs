using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBars : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image life, mana;

    // Update is called once per frame
    void Update()
    {
        life.fillAmount = (float)player.life / player.lifeMax;
        mana.fillAmount = (float)player.mana / player.manaMax;
    }
}
