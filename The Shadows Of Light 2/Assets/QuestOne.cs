using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOne : MonoBehaviour
{
    public GameObject Player;
    public GameObject game_manager;
    public int required_stepcount;
    public int current_stepcount;
    public bool step_completed;
    public bool quest_completed;

    [Header("Step Variables")]
    public GameObject step1_waypoint;


    public float test;

    QuestSystem quest_system;

    private void Start()
    {
        quest_system = game_manager.GetComponent<QuestSystem>();
    }
    private void Update()
    {
        quest_system.objective_flag = current_stepcount;
        if (current_stepcount == 1)
        {
            step_one();
        }
        test = Vector3.Distance(Player.transform.position, step1_waypoint.transform.position);
    }
    //step one, explore the island
    #region step one : Explore the Island
    public void step_one()
    {
        //quest_system.waypoint = step1_waypoint;
        if (quest_system.reach(step1_waypoint))
        {
            Debug.Log("Play Animation");
            next_step();
        }
        else
        {
            Debug.Log("Not reached");
        }
      
    }
    #endregion
    #region step two : Follow The Creature
    public void step_two()
    {

    }
    #endregion
    public void next_step()
    {
        current_stepcount = Mathf.Min(current_stepcount + 1, required_stepcount);
        if(current_stepcount>= required_stepcount && !quest_completed)
        {
            this.quest_completed = true;
        }
    }
   
    public void quest_complete()
    {
        //completed = true;
        if(quest_completed == true)
        {
            //end quest
        }
    }
    

}
