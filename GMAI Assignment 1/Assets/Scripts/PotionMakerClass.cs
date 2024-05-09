using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakerClass : MonoBehaviour
{
    /*------- v STATES v -------*/
    public PotionMakerStates m_Idle { get; set; } = null;
    public PotionMakerStates m_Brewing { get; set; } = null;
    public PotionMakerStates m_Requesting { get; set; } = null;
    public PotionMakerStates m_Studying { get; set; } = null;
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
    public GameObject btn_Inquire; // For Attending -> Potion Inquiry
    public GameObject btn_Leave; // For Attending -> Idle
    public GameObject btn_Healing; // For Potion Inquiry -> Transaction
    public GameObject btn_Arcane; // For Potion Inquiry -> Studying
    public GameObject btn_Pay; // For Transaction -> Attending

    /*------- v OTHER VARIABLES v -------*/
    public bool inOneSession; // This variable is mainly for Transaction -> Attending, so that the potion maker asks something different if the player doesn't leave.

    // Start is called before the first frame update
    void Start()
    {
        //First, initialize into the Idle State (a.k.a the opening state).
        m_Idle = new IdleState(this);
        m_Current = m_Idle;
        m_Current.Enter();
        inOneSession = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Current.Execute();
    }

    // The following OnClick functions (like ApproachOnClick, TalkOnClick and InquireOnClick) are all here
    // so that we can call them from our buttons' OnClick functions from Unity.
    // We can't normally just call the functions that are called within these OnClicks since they are stored inside
    // the state scripts themselves, and PotionMakerStates and its subclasses are not attached to any GameObject.
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

    public void InquireOnClick()
    {
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(AttendingState))
            {
                ((AttendingState)m_Current).Inquired();
            }
        }
    }

    public void LeaveOnClick()
    {
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(AttendingState))
            {
                ((AttendingState)m_Current).LeaveShop();
            }
        }
    }

    public void HealingOnClick()
    {
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(PotionInquiryState))
            {
                ((PotionInquiryState)m_Current).ChooseHealingPotion();
            }
        }
    }

    public void ArcaneOnClick()
    {
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(PotionInquiryState))
            {
                ((PotionInquiryState)m_Current).ChooseArcanePotion();
            }
        }
    }

    public void PayOnClick()
    {
        if (m_Current != null)
        {
            if (m_Current.GetType() == typeof(TransactionState))
            {
                ((TransactionState)m_Current).PayForPotion();
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
