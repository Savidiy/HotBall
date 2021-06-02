using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HotBall
{
    public static class Extensions
    {
        public static int CountChar(this string str, char ch)
        {
            // Реализовать метод расширения для поиска количество символов в строке
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                    count++;
            }

            return count;
        }
    }

    public class Task5 : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("<color=red>Problem 2</color>");
            Task5_2();

            Debug.Log("<color=red>Problem 3</color>");
            Task5_3();

            Debug.Log("<color=red>Problem 4</color>");
            Task5_4();
        }

        private void Task5_2()
        {
            string text = "Бобер грыз бревно, пока не бросил это неблагодарное и бесполезное дело.";
            char ch = 'б';
            int count = text.CountChar(ch);
            Debug.Log($"В строке \"{text}\" буква \"{ch}\" встречается {count} раз");
        }

        private void Task5_3()
        {
            List<int> list = new List<int> {5, 3, 4, 5, 3, 3, 2, 1, 2};
            string text = "List = ";
            foreach (int i in list)
                text += $"{i} ";
            Debug.Log(text);

            var a1 = CountElementInInt(list);
            Print("A1", a1);
            var a2 = CountElementIn<int>(list);
            Print("A2", a2);
            var a3 = CountElementWithLinq<int>(list);
            Print("A3", a3);
        }

        // Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
        
        // для целых чисел;
        private Dictionary<int, int> CountElementInInt(IEnumerable<int> list)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (int value in list)
            {
                if (counts.ContainsKey(value))
                    counts[value]++;
                else
                    counts.Add(value, 1);
            }

            return counts;
        }

        // * для обобщенной коллекции;
        private Dictionary<T, int> CountElementIn<T>(IEnumerable<T> list)
        {
            Dictionary<T, int> counts = new Dictionary<T, int>();

            foreach (T value in list)
            {
                if (counts.ContainsKey(value))
                    counts[value]++;
                else
                    counts.Add(value, 1);
            }

            return counts;
        }

        // ** используя Linq.
        private Dictionary<T, int> CountElementWithLinq<T>(IEnumerable<T> list)
        {
            Dictionary<T, int> counts = list.GroupBy(p => p)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
            return counts;
        }

        private static void Print(string name, Dictionary<int, int> a1)
        {
            string text = name + "\n";
            foreach (KeyValuePair<int, int> pair in a1)
            {
                text += $"{pair.Key} - {pair.Value} time(s)\n";
            }

            Debug.Log(text);
        }

        private void Task5_4()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4},
                {"two", 2},
                {"one", 1},
                {"three", 3},
            };

            // * Дан фрагмент программы:
            var d = dict.OrderBy(delegate(KeyValuePair<string, int> pair) { return pair.Value; });
            Debug.Log("Original");
            Print(d);

            // а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
            var da = dict.OrderBy(pair => pair.Value);
            Debug.Log("Variant A");
            Print(da);

            // b. * Развернуть обращение к OrderBy с использованием делегата
            Func<KeyValuePair<string, int>, int> criteria = GetValue;
            var db = dict.OrderBy(criteria);
            Print(db);
        }

        private static int GetValue(KeyValuePair<string, int> pair)
        {
            return pair.Value;
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