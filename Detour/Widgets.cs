using System.Text.RegularExpressions;
using RimWorld;
using UnityEngine;
using Source = Verse.Widgets;

namespace AlcoholV.Detour
{
    internal static class Widgets
    {
        public static string TextField(Rect rect, string text, int maxLength, Regex inputValidator)
        {
            var text2 = Source.TextField(rect, text);
            if (text2.Length <= maxLength)
            {
                return text2;
            }
            return text;
        }

        public static void DoNameInputRect(Rect rect, ref string name, int maxLength)
        {
            string str = Source.TextField(rect, name);
            if (str.Length <= maxLength)
            {
                name = str;
            }
        }
    }

}