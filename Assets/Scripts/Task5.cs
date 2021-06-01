using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HotBall
{
    public class Task5 : MonoBehaviour
    {
        private static void Print(string name, Dictionary<int, int> a1)
        {
            string text = name + "\n";
            foreach (KeyValuePair<int, int> pair in a1)
            {
                text += $"{pair.Key} - {pair.Value} time(s)\n";
            }

            Debug.Log(text);
        }
        
        private static void Print(IOrderedEnumerable<KeyValuePair<string, int>> d)
        {
            string text = "";
            foreach (var pair in d)
            {
                text += $"{pair.Key} - {pair.Value} \n";
            }
            Debug.Log(text);
        }
    }
}