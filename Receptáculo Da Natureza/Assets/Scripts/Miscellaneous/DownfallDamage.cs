using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownfallDamage : MonoBehaviour
{
    /*Player player;
    [SerializeField] Transform[] spots;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {

    }

    public Vector2 downfall() 
    {
        Vector2 nearSpot = Vector2.zero;
       
        Vector2 playerSpot = player.transform.position;
        float MIN = float.PositiveInfinity;
        foreach(Transform spot in spots)
        {
            if(nearSpot.x == 0 && nearSpot.y == 0)
            {
                nearSpot = spot.position;
                MIN = Vector2.Distance(playerSpot, nearSpot);

            }

            else if(Vector2.Distance(playerSpot, spot.position) < MIN)
            {
                nearSpot = spot.position;
                MIN = Vector2.Distance(playerSpot, nearSpot);
            }
        }
        return (nearSpot);
    }*/

}
