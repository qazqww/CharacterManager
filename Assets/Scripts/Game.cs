using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{

}

public class Game 
{
    public static int m_charUniqueID = 0;
    public static int CH_UNIQUEID
    {
        get { return ++m_charUniqueID; }
    }
        
    public static UserInfo m_userInfo = new UserInfo();
    public static CharMng m_charMng = new CharMng();
    public static DataMng m_dataMng = new DataMng();
}
