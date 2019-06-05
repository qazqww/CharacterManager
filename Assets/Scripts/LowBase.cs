using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowBase 
{
    private Dictionary<int, Dictionary<string, string>> m_dataTable = new Dictionary<int, Dictionary<string, string>>();



    private bool CheckContains( int tableID, string subject )
    {
        if (m_dataTable.ContainsKey(tableID))
        {
            if (m_dataTable[tableID].ContainsKey(subject))
                return true;
        }
        return false;
    }

    public int ToI(int tableID, string subject )
    {
        int tableValue = 0;

        if(CheckContains( tableID, subject ))
        { 
            string valString = m_dataTable[tableID][subject];
            int.TryParse(valString, out tableValue);
        }

        return tableValue;
    }

    public float ToF(int tableID, string subject)
    {
        float tableValue = 0;
        if (CheckContains(tableID, subject))
        {
            string valString = m_dataTable[tableID][subject];
            float.TryParse(valString, out tableValue);
        }
        return tableValue;
    }

    public string ToS(int tableID, string subject)
    {
        string tableValue = string.Empty;
        if (CheckContains(tableID, subject))
        {
            tableValue = m_dataTable[tableID][subject];
        }
        return tableValue;
    }

    public void Load(string table)
    {
        string[] row = table.Split('\n');

        int count = 0;
        string lastStr = row[row.Length - 1];

        if (string.IsNullOrEmpty(lastStr))
            count++;

        for( int i = 0; i< row.Length - count; ++ i )
        {
            row[i] = row[i].Replace('\r', ' ');
            row[i] = row[i].Trim();
        }

        string[] subject = row[0].Split(',');

        int uniqueindex = 0;
        for( int i = 0; i< subject.Length; ++ i )
        {
            if( subject[i].Equals("IDX") )
            {
                uniqueindex = i;
                break;
            }
        }

        for(int rowCount = 1; rowCount < row.Length - count; ++rowCount)
        {
            string[] column = row[rowCount].Split(',');
            int uniqueID;
            int.TryParse(column[uniqueindex], out uniqueID);

            if( ! m_dataTable.ContainsKey( uniqueID ) )
                m_dataTable.Add(uniqueID, new Dictionary<string, string>());
            
            for ( int i = 0; i< subject.Length; ++ i )
            {
                if (i == uniqueindex)
                    continue;

                m_dataTable[uniqueID].Add(subject[i], column[i]);
            }
        }
    }

    public List<int> GetKeys()
    {
        List<int> keys = new List<int>();

        foreach( var key in m_dataTable.Keys )
        {
            keys.Add(key);
        }
        return keys;
    }
}