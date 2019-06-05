using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionGame;

public class GameHelper : MonoBehaviour
{
    private static GameHelper m_gameHelper;

    // Start is called before the first frame update
    void Awake()
    {
        m_gameHelper = this;
        Game.m_dataMng.Load("Table/", TableType.HeroTable);
    }

    private void OnGUI()
    {
        if( GUI.Button( new Rect( 0, 0, 100, 100 ), "캐릭터 생성" ))
        {
            AddChar(ActionGame.CharType.Hero, 0, Vector3.zero, Quaternion.identity, null, null);
        }
    }
    
    // 동기 함수입니다.
    public static IChar AddChar( CharType charType, int tableIdx, Vector3 pos, Quaternion rot, Transform parent)
    {
        if( charType == CharType.Hero )
        {
            string modelPath = Game.m_dataMng.Get(TableType.HeroTable).
                ToS(tableIdx, "PREFAB");

            BaseChar hero = Instantiate( Resources.Load<BaseChar>(modelPath), pos, rot, parent);                  

            // 캐릭터에 대한 정보를 설정하는 코드가 차후 추가될 예정입니다.

            // 캐릭터 매니저에 생성된 캐릭터를 등록합니다.            
            Game.m_charMng.Add(Game.CH_UNIQUEID, tableIdx, hero);
            return hero;
        }       
        return null;
    }

    // 비동기 함수를 호출합니다.
    public static void AddChar(CharType charType, int tableIdx, Vector3 pos, Quaternion rot,
                                Transform parent, BaseChar baseChar)
    {
        m_gameHelper.StartCoroutine(AddCharAsync(charType, tableIdx ,pos, rot, parent, baseChar));
    }

    public static IEnumerator AddCharAsync(CharType charType, int tableIdx, Vector3 pos, Quaternion rot,
                                            Transform parent, BaseChar refChar = null )
    {
        if (charType == CharType.Hero)
        {
            string modelPath = Game.m_dataMng.Get(TableType.HeroTable).ToS(tableIdx, "PREFAB");
            bool load = false;
            ResourceRequest request = Resources.LoadAsync<BaseChar>(modelPath);

            while (!load)
            {
                if (request.isDone)
                    load = true;

                yield return null;
            }

            BaseChar hero = Instantiate(request.asset as BaseChar, pos, rot, parent);
            refChar = hero;
            // 캐릭터에 대한 정보를 설정하는 코드가 차후 추가될 예정입니다.

            // 캐릭터 매니저에 생성된 캐릭터를 등록합니다.
            Game.m_charMng.Add(Game.CH_UNIQUEID, tableIdx, hero);
        }

        yield return null;
    }


}
