using System.Reflection;
using System.Text.RegularExpressions;
using AlcoholV.NoCCL;
using RimWorld;
using UnityEngine;
using Verse;

namespace AlcoholV
{
    public class UnlimitedValidation_SpecialInjector : SpecialInjector
    {
        public override bool Inject()
        {
            var para1 = new[] {typeof(Rect), typeof(string), typeof(int), typeof(Regex)};

            if (!Detours.TryDetourFromTo(
                typeof(Widgets).GetMethod("TextField", BindingFlags.Static | BindingFlags.Public, null, para1, null),
                typeof(Detour.Widgets).GetMethod("TextField")
            )) return false;

            // change regex
            var fieldInfo = typeof(CharacterCardUtility).GetField("validNameRegex", BindingFlags.Static | BindingFlags.NonPublic);
            if (fieldInfo != null) fieldInfo.SetValue(typeof(CharacterCardUtility), new Regex(""));
            else return false;

            fieldInfo = typeof(Dialog_ManageAreas).GetField("validNameRegex", BindingFlags.Static | BindingFlags.NonPublic);
            if (fieldInfo != null) fieldInfo.SetValue(typeof(Dialog_ManageAreas), new Regex(""));
            else return false;

            return true;
        }
    }
}