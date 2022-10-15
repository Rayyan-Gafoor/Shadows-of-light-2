using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    //linear quest 
    public GameObject Player;
    public GameObject quest_name, quest_objective;
    public int active_quest = 0;
    public int quest_flag = 0;// change this when quest is completed 1= active 2= complete
    public int objective_flag = 0;//search around//follow creature//break wall//enter portal
  
    private void Start()
    {
        active_quest = 1;
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            objective_flag = objective_flag + 1;
        }*/
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
            quest_flag = 1; //sets the first quest active
        }
        else if (active_quest == 2)
        {
            quest_flag = 2;
        }
        else if (active_quest == 3)
        {
            quest_flag = 3;
        }

    }
    #region Quest One

    void quest_one_UIhandler()
    {
        if (quest_flag == 1)//quest is active 2= not active
        {
            quest_name.GetComponent<TMPro.TextMeshProUGUI>().text = "What is Loneliness";
            if (objective_flag == 1)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Explore the Island";
            }
            else if (objective_flag == 2)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Return to your Cave";
            }
            else if (objective_flag == 3)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Follow the Creature";
            }
            else if (objective_flag == 4)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Destroy the Wall";

            }
            else if (objective_flag == 5)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Enter the MYSTERIOUS portal";
            }
            else if (objective_flag == 6)
            {
                //quest_objective.text = "Enter the MYSTERIOUS portal";
                active_quest = 2;
            }
        }
    }

    #endregion
    #region Quest Two

    void quest_two_UIhandler()
    {
        if (quest_flag == 2)//quest is active 2= not active
        {
            quest_name.GetComponent<TMPro.TextMeshProUGUI>().text = "this is quest two";
            if (objective_flag == 1)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Explore the Abysal Hollows";
            }
            else if (objective_flag == 2)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Find the Stranger";
            }
            else if (objective_flag == 3)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Speak to Zi";
            }
            else if (objective_flag == 4)
            {
                quest_objective.GetComponent<TMPro.TextMeshProUGUI>().text = "Find a way out";
            }
            else if (objective_flag == 5)
            {
                //quest_objective.text = "Enter the MYSTERIOUS portal";
                active_quest = 2;
            }
        }
    }

    #endregion

    #region Quest Type Functions
    public bool reach(GameObject waypoint)
    {
        float offset_value = 5f;
        if (offset_value > Vector3.Distance(Player.transform.position, waypoint.transform.position))
        {
            return true;
        }
        else return false;
    }
    public bool destroy(GameObject obstruction)
    {
        if (obstruction == null)
        {
            return true;
        }
        else return false;
    }
    public bool follow(GameObject leader)
    {
        float offset_value = 0.1f;
        if (offset_value > Vector3.Distance(Player.transform.position, leader.transform.position))
        {
            return true;
        }
        else return false;
    }
    public bool interact(bool interactor)
    {
        if (interactor)
        {
            return true;
        }
        else return false;
    }
    #endregion
}
