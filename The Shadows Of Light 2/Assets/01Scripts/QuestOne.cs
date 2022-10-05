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
    public GameObject step1_leader;// Dam
    public GameObject step2_leader;// home 
    public GameObject step3_leader;// creature to follow
    public GameObject step4_obstruction;// wall to destroy

    Leader leader1, leader2, leader3;

    public float test;

    QuestSystem quest_system;

    private void Start()
    {
        quest_system = game_manager.GetComponent<QuestSystem>();
        leader1 = step1_leader.GetComponent<Leader>();
        leader2 = step2_leader.GetComponent<Leader>();
        leader3 = step3_leader.GetComponent<Leader>();
    }
    private void Update()
    {
        quest_system.objective_flag = current_stepcount;
        if (current_stepcount == 1)
        {
            step_one();
        }
        if (current_stepcount == 2)
        {
            step_two();
        }
        if (current_stepcount == 3)
        {
            step_three();
        }
        if (current_stepcount == 4)
        {
            step_four();
        }

        test = Vector3.Distance(Player.transform.position, step1_leader.transform.position);
    }
    //step one, explore the island
    #region step one : Explore the Island
    public void step_one()
    {
        //quest_system.waypoint = step1_waypoint;
        if (leader1.leader_stoped==true)
        {
            Debug.Log("Play Animation");
            StartCoroutine(next_step());
        }
        else
        {
           // Debug.Log("Not reached");
        }
      
    }
    #endregion
    #region step two : Return Home
    public void step_two()
    {
        //quest_system.waypoint = step1_waypoint;
        if (leader3.leader_stoped == true)
        {
            Debug.Log("Play Animation");
            StartCoroutine(next_step());
        }
        else
        {
            Debug.Log("Not reached");
        }

    }
    #endregion
    #region step three : Follow The Creature
    public void step_three()
    {
        if (leader3.leader_stoped == true)
        {
            Debug.Log("Play second step animation");
            StartCoroutine(next_step());
        }
    }
    #endregion
    #region step four : Destroy the Wall
    public void step_four()
    {
        if (step4_obstruction == null)
        {
            Debug.Log("Object is destroyed");
            StartCoroutine(next_step());
        }
    }
    #endregion
    public IEnumerator next_step()
    {
        //disable UI...
        current_stepcount = Mathf.Min(current_stepcount + 1, required_stepcount);
        if(current_stepcount>= required_stepcount && !quest_completed)
        {
            this.quest_completed = true;
            
        }
        yield return new WaitForSeconds(1);

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
