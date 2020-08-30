using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tempus.CoroutineTools
{
    public static class Yield
    {
        public const object Frame = null;
        public static readonly WaitForEndOfFrame EndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate FixedUpdate = new WaitForFixedUpdate();

        private static readonly Dictionary<float, WaitForSeconds> SecondsDictionary = new Dictionary<float, WaitForSeconds>();
        private static readonly Dictionary<float, WaitForSecondsRealtime> SecondsRealtimeDictionary = new Dictionary<float, WaitForSecondsRealtime>();
        private static readonly Dictionary<Func<bool>, WaitUntil> UntilDictionary = new Dictionary<Func<bool>, WaitUntil>();
        private static readonly Dictionary<Func<bool>, WaitWhile> WhileDictionary = new Dictionary<Func<bool>, WaitWhile>();

        public static WaitForSeconds Seconds(float seconds)
        {
            if (!SecondsDictionary.ContainsKey(seconds))
            {
                SecondsDictionary.Add(seconds, new WaitForSeconds(seconds));
            }
            return SecondsDictionary[seconds];
        }

        public static WaitForSecondsRealtime SecondsRealtime(float seconds)
        {
            if (!SecondsRealtimeDictionary.ContainsKey(seconds))
            {
                SecondsRealtimeDictionary.Add(seconds, new WaitForSecondsRealtime(seconds));
            }
            return SecondsRealtimeDictionary[seconds];
        }

        public static WaitUntil Until(Func<bool> predicate)
        {
            if (!UntilDictionary.ContainsKey(predicate))
            {
                UntilDictionary.Add(predicate, new WaitUntil(predicate));
            }
            return UntilDictionary[predicate];
        }

        public static WaitWhile While(Func<bool> predicate)
        {
            if (!WhileDictionary.ContainsKey(predicate))
            {
                WhileDictionary.Add(predicate, new WaitWhile(predicate));
            }
            return WhileDictionary[predicate];
        }
    }
}
