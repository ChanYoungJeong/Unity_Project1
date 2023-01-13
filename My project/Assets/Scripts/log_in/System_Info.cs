using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Info : MonoBehaviour
{
    public string UserAccount;
    public int Load_Stage;
    public int Load_Gold;
    public int Player_Attack_Rate;
    public int Player_Hp_Rate;
    public int Player_LV;
    public int Player_EXP;

    public bool Rogue_Active;
    public bool MagicCaster_Active;
    public bool Priest_Active;
    public bool Archer_Active;
    public bool Alchemist_Active;

    public void SetLoading(string ID, int Stage, int Gold, int PlayerAttack, int PlayerHp, int PlayerLV, int PlayerEXP
                            , bool RogueAct, bool MagicCasterAct, bool PriestAct, bool ArcherAct, bool AlchemistAct)
    {
        UserAccount = ID;
        Load_Stage = Stage;
        Load_Gold = Gold;
        Player_Attack_Rate = PlayerAttack;
        Player_Hp_Rate = PlayerHp;
        Player_LV = PlayerLV;
        Player_EXP = PlayerEXP;
        //
        Rogue_Active = RogueAct;
        MagicCaster_Active = MagicCasterAct;
        Priest_Active = PriestAct;
        Archer_Active = ArcherAct;
        Alchemist_Active = AlchemistAct;
    }
}
