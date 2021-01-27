using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIUpdater : CoreUIElement<Vector2>
{
    protected Animator playerAnim;
    protected Vector2 lastPos;

    protected void Start()
    {
        if (playerAnim == null)
            playerAnim = GetComponent<Animator>();
    }

    public override void UpdateUI(Vector2 primaryData)
    {
        if (ClearedIfEmpty(primaryData))
            return;

        lastPos = primaryData;
        //based on V2 playerAnim.play(Animation);
    }

    protected override bool ClearedIfEmpty(Vector2 newData)
    {
        if (newData == Vector2.zero)
        {
            //play Idle animation with lastPos;
            return true;
        }
        return false;            
    }
}
