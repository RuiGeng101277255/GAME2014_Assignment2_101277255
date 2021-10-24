/*
 Full Name: Rui Chen Geng Li (101277255)
 File Name: PlayerLayout.cs
 Last Modified: October 24th, 2021
 Description: Places a player attack at a particular layout grid
 Version History: v1.12 Cleaned Up Codes and Comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayout : MonoBehaviour
{
    //Variables for the grid system and the grid buttons
    public GameObject PlaceableGrids;
    public GameObject GridButtons;
    //Variables that will help define the flip, rotation, the manager and type for the player to be spawned
    public float ZRot;
    public bool Flip = false;
    public PlayerManager manager;

    private AttackTypes setType;

    public void SetPlayerType (AttackTypes type)
    {
        //sets player to be spawned to this type
        setType = type;
    }

    public void PlacePlayer()
    {
        //places the player at this grid layout's position along with a rotation so that the player is at the best attack angle
        manager.PlacePlayer(setType, transform.position, ZRot);

        //destroys the gameobject so it can't spawn another player on top
        Destroy(gameObject);

        //Hides the grid system and the buttons
        PlaceableGrids.SetActive(false);
        GridButtons.SetActive(false);
    }
}
