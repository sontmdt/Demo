using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSkill : AnimationEventManager
{
    public void StartDamage()
    {
        skillCtrl.DamageManager.BoxCollider.enabled = true;
        //Debug.Log("jskkndknsdv");
    }
}
