using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TableType
{
    HeroTable,
    MonTable,
    SelectCharacter,
    English,
    StageTable,
}

public class DataMng
{
    private Dictionary<TableType, LowBase> m_table = new Dictionary<TableType, LowBase>();

    public  LowBase Get( TableType tableType )
    {
        if (m_table.ContainsKey(tableType))
            return m_table[tableType];

        return null;
    }

    public int ToI( TableType tableType, int tableID, string subject )
    {        
        if (m_table.ContainsKey(tableType))
            return m_table[tableType].ToI(tableID, subject);

        return -1;
    }
    public  float ToF(TableType tableType, int tableID, string subject)
    {

        if (m_table.ContainsKey(tableType))
            return m_table[tableType].ToF(tableID, subject);

        return -1;
    }
    public  string ToS(TableType tableType, int tableID, string subject)
    {

        if (m_table.ContainsKey(tableType))
            return m_table[tableType].ToS(tableID, subject);

        return string.Empty;
    }

    public void Load( string path, TableType tableType )
    {
        if (m_table.ContainsKey(tableType))
            return;

        TextAsset textAsset = Resources.Load<TextAsset>(path + tableType);
        if( textAsset != null )
        {
            LowBase lowBase = new LowBase();
            lowBase.Load(textAsset.text);
            m_table.Add(tableType, lowBase);
        }
    }
}
