using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tempus.CoroutineTools
{
    public static class Yield
    {
        public static readonly object Frame = null;
        public static readonly WaitForEndOfFrame EndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate FixedUpdate = new WaitForFixedUpdate();

        private static Dictionary<float, WaitForSeconds> secondsDictionary = new Dictionary<float, WaitForSeconds>();
        private static Dictionary<float, WaitForSecondsRealtime> secondsRealtimeDictionary = new Dictionary<float, WaitForSecondsRealtime>();
        private static Dictionary<Func<bool>, WaitUntil> untilDictionary = new Dictionary<Func<bool>, WaitUntil>();
        private static Dictionary<Func<bool>, WaitWhile> whileDictionary = new Dictionary<Func<bool>, WaitWhile>();

        public static WaitForSeconds Seconds(float seconds)
        {
            if (!secondsDictionary.ContainsKey(seconds))
            {
                secondsDictionary.Add(seconds, new WaitForSeconds(seconds));
            }
            return secondsDictionary[seconds];
        }

        public static WaitForSecondsRealtime SecondsRealtime(float seconds)
        {
            if (!secondsRealtimeDictionary.ContainsKey(seconds))
            {
                secondsRealtimeDictionary.Add(seconds, new WaitForSecondsRealtime(seconds));
            }
            return secondsRealtimeDictionary[seconds];
        }

        public static WaitUntil Until(Func<bool> predicate)
        {
            if (!untilDictionary.ContainsKey(predicate))
            {
                untilDictionary.Add(predicate, new WaitUntil(predicate));
            }
            return untilDictionary[predicate];
        }

        public static WaitWhile While(Func<bool> predicate)
        {
            if (!whileDictionary.ContainsKey(predicate))
            {
                whileDictionary.Add(predicate, new WaitWhile(predicate));
            }
            return whileDictionary[predicate];
        }
    }
}
