using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PotionMakerStates
{
    private bool isBeingApproached = false;
    public IdleState(PotionMakerClass potionMaker)
    {
        // m_PotionMaker comes from PotionMakerStates.
        m_PotionMaker = potionMaker;
    }

    public override void Enter()
    {
        Debug.Log("The Kobold's Beaker is ready for business!");
        m_PotionMaker.btn_Approach.SetActive(true);
    }

    public override void Execute()
    {
        if (isBeingApproached == true)
        {
            // If the Potion Maker is being approached, transition to the Approached state.
            Debug.Log("Set to true!");
        }
        else
        {
            Debug.Log("Waiting for customers...");
        }
    }

    public override void Exit()
    {
        Debug.Log("The doors to the Kobold's Beaker open.");
    }

    public void ApproachPotionMaker()
    {
        isBeingApproached = true;
    }
}
