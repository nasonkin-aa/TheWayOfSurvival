
public class PlayerLvlWithLvlUp : PlayerLvl
{
    public void LvlUp()
    {
        GetExp(ExpToLvlUp - PlayerExp);
    }
}
