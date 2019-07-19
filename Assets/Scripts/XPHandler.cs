using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        Debug.Log("Finished the fight, I need to add some XP!");
        if (data.outcome >= 0)
        {
            data.player.xp += 50;
            GameEvents.PlayerXPGain(50);
            CheckForLevelling(data);
        }
    }

    public void CheckForLevelling(BattleResultEventData data)
    {
        if ((data.player.xp > 0) && (data.player.level <= 0))
        {
            data.player.level = 1;
            GameEvents.PlayerLevelUp(1);
        }
        else if ((data.player.xp > 200) && (data.player.xp >= 200))
        {
            data.player.level += 1;
            data.player.luck += 1;
            data.player.style += 2;
            data.player.rhythm += 3;
            data.player.xp =0;
        }

    }
        

}
