public class WeaponFly : ASkillFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 20;
    }
}
