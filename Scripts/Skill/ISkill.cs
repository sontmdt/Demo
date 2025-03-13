using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    public float coolDown { get; }
    public float lastUsedTime { get; set; }
    public void UseSkill();

    public void UseSkill(string SkillName, Vector3 position)
    {
        //
    }
    public bool CanUseSkill();
}
