﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        Debug.Log("We’re fighting! We need to check some stats and set an outcome!");

        float outcome = 0;
        if (data.player.style > data.npc.style)
        {
            outcome = 1;
        }
        else if (data.player.style == data.npc.style)
        {
            outcome = 0;
        }
        else
        {
            outcome = -1;
        }

        Debug.Log("Outcome = 1, player maximum!");

        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
