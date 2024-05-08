using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakerClass : MonoBehaviour
{
    /*------- v STATES v -------*/
    public PotionMakerStates m_Idle { get; set; } = null;
    public PotionMakerStates m_Brewing { get; set; } = null;
    public PotionMakerStates m_Requesting { get; set; } = null;
    public PotionMakerStates m_Researching { get; set; } = null;
    public PotionMakerStates m_CheckComponents { get; set; } = null;
    public PotionMakerStates m_Transaction { get; set; } = null;
    public PotionMakerStates m_PotionInquiry { get; set; } = null;
    public PotionMakerStates m_Failed { get; set; } = null;
    public PotionMakerStates m_Cleaning { get; set; } = null;
    public PotionMakerStates m_Approached { get; set; } = null;
    public PotionMakerStates m_Attending { get; set; } = null;
    public PotionMakerStates m_Current { get; set; } = null;

    /*------- v BUTTONS v -------*/
    public GameObject btn_Approach; // For Idle -> Approach
    public GameObject btn_Talk; // For Approach -> Attending

    // Start is called before the first frame update
    void Start()
    {
        //First, initialize into the Idle State (a.k.a the opening state).
        m_Idle = new IdleState(this);
        m_Current = m_Idle;
        m_Current.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        m_Current.Execute();
    }

    public void ApproachOnClick()
    {
        // Activate the ApproachPotionMaker() function in the Idle State script.
        if (m_Current != null)
        {
            // Though first, let's make sure to check if the current state is the Idle state.
            if (m_Current.GetType() == typeof(IdleState))
            {
                ((IdleState)m_Current).ApproachPotionMaker();
            }
        }
    }

    public void TalkOnClick()
    {
        // Following the logic for ApproachOnClick().
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(ApproachedState))
            {
                ((ApproachedState)m_Current).TalkToPotionMaker();
            }
        }
    }

    public void ChangeState(PotionMakerStates nextState)
    {
        // If we do have a state under m_Current, run the Exit().
        if (m_Current != null)
        {
            m_Current.Exit();
        }

        m_Current = nextState;
        m_Current.Enter();
    }
}
