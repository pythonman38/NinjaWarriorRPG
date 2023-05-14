using UnityEngine;

public class DashSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();

        Debug.Log("Created close to leave behind!");
    }
}
