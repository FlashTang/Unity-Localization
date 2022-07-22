using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public enum LANG:int{
    EN = SystemLanguage.English, //英语 English
    JA = SystemLanguage.Japanese, //日语 Japanese
    //KO = SystemLanguage.Korean, //朝鲜语 Korean
    CN = SystemLanguage.ChineseSimplified, //简体中文
    TW = SystemLanguage.ChineseTraditional, //繁体中文
    //AR = SystemLanguage.Arabic, // 阿拉伯语 Arabic
    //DE = SystemLanguage.German, //德语 German
    //FR = SystemLanguage.French, //法语
    PT = SystemLanguage.Portuguese, //葡萄牙语（巴西，葡萄牙）
    //TH = SystemLanguage.Thai, //泰语
    //RU = SystemLanguage.Russian, //俄语
    //RO = SystemLanguage.Romanian, //罗马尼亚语
    //VI = SystemLanguage.Vietnamese, //越南语
    //UK = SystemLanguage.Ukrainian, //乌克兰语
}

public class Localization : MonoBehaviour {
    
    List<string> countryCodes;
 
    public void AutoSwitchLanguage(){
        var values = System.Enum.GetValues(typeof(LANG));
        int max = values.Cast<int>().Max();
        countryCodes = new string[max].ToList();
         
        var index  = 0;
        var names = System.Enum.GetNames(typeof(LANG));
        foreach (int i in values)
            countryCodes[i-1] = names[index++];
       
         
        if(System.Enum.IsDefined(typeof(LANG),((int)Application.systemLanguage))){ //获取支持的语言
            SetLang(Application.systemLanguage);
        }
        else{
            SetLang(SystemLanguage.English);
        } 
    }

    void SetLang(SystemLanguage language){
        foreach(RectTransform child in gameObject.transform.GetComponentsInChildren<RectTransform>(true)){
            if(child.gameObject.name.Contains("LOC_TMP")){
                if(child.gameObject.name.Contains("TMP_"+countryCodes[((int)language) - 1])){
                    child.gameObject.SetActive(true);
                }
                else{
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
