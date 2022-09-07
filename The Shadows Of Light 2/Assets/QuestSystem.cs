using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    //linear quest 
    public GameObject quest_name, quest_objective;
    public int active_quest = 0;
    public int quest1_flag = 0;// change this when quest is completed 1= active 2= complete
    public int objective1_flag = 0;//search around//follow creature//break wall//enter portal
    public int quest2_flag = 0;// change this when quest is completed 1= active 2= complete
    public int objective2_flag = 0;//search around//follow creature//break wall//enter portal

    private void Start()
    {
        active_quest = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            objective1_flag = objective1_flag + 1;
        }
        quest_handler();
        quest_one_UIhandler();

    }
    //quest one will conist of 4 sequential objectives.
    //we must determin which quest and object is active is active.
    //when a quest is completed and switch to the next quest.
    //which quests are completed.

    void quest_handler()
    {
        if (active_quest == 1)
        {
            quest1_flag = 1; //sets the first quest active
        }
        else
        {
            quest1_flag = 2;
        }
    }
    #region Quest One
    
    void quest_one_UIhandler()
    {
        if (quest1_flag == 1)//quest is active 2= not active
        {
        quest_name.GetComponent<TMPro.TextMeshProUGUI>().text = "this is quest one";
            if (objective1_flag == 1)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Explore the island";
            }
            else if (objective1_flag == 2)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Follow the creature";
            }
            else if (objective1_flag == 3)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Destroy the Wall";
            }
            else if (objective1_flag == 4)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Enter the MYSTERIOUS portal";
            }
            else if (objective1_flag == 5)
            {
                //quest_objective.text = "Enter the MYSTERIOUS portal";
                active_quest = 2;
            }
        }
    }

    #endregion
}
