using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakerClass : MonoBehaviour
{
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
        
    }

    public void ExecuteOnClick()
    {
        // Filling this in for now.
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
