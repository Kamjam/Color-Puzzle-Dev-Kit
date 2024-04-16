using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameColorPalette", menuName = "GameColorPalette", order = 0)]
public class GameColorPalette : ScriptableObject
{
    [System.Serializable]    
    public class Entry 
    {
        public string name;
        public Color color;
    }

    public List<Entry> palette = new List<Entry>();

    public string GetColor(string name) 
    { 
        var entry = palette.Find(c => c.name == name);
        if (entry != null)
            //return entry.color;
            return name;
            
        //return Color.white;
        return null;
    }

    public Color SetColor(string name) 
    { 
        var entry = palette.Find(c => c.name == name);
        if (entry != null)
            return entry.color;
            
        return Color.white;
    }
}

//source:https://gamedev.stackexchange.com/questions/167014/how-can-i-use-the-colours-of-a-swatch-in-a-script