using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpDrop : Collidable
{
    public int xpValue = 1;
    private string playerName = "Player";

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerName)
        {
            GiveXp();
        }
    }

    private void GiveXp()
    {
        GameManager.instance.AddExperience(xpValue);
        Destroy(gameObject);
    }
}
