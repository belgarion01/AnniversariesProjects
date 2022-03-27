using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressHusbandMinigame : Minigame
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void StartMinigame(Player player)
    {
        if (IsMinigameFinished) return;
        
        base.StartMinigame(player);

        player.MovementComponent.Enabled = false;
    }

    public override void EndMinigame(bool succeeded)
    {
        base.EndMinigame(succeeded);

        _player.MovementComponent.Enabled = true;
    }

    public void OnFinishPressed()
    {
        EndMinigame(true);
    }
}
