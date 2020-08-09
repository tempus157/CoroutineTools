using System;
using System.Collections;
using UnityEngine;

namespace Tempus.CoroutineTools
{
    public static class ExtensionMethods
    {
        private static CoroutineToolsComponent component;
        private static CoroutineToolsComponent Component
        {
            get
            {
                if (component == null)
                {
                    component = new GameObject("CoroutineTools").AddComponent<CoroutineToolsComponent>();
                }
                return component;
            }
        }

        public static IEnumerator Start(this IEnumerator coroutine)
        {
            if (Component.IsStarted(coroutine))
            {
                throw new ArgumentException("Coroutine has already started");
            }

            var coroutineYield = Component.StartCoroutine(coroutine);
            var yield = Component.StartCoroutine(Remove(coroutine, coroutineYield));
            Component.AddCoroutine(coroutine, yield);
            return coroutine;
        }

        public static Coroutine WaitForCompletion(this IEnumerator coroutine)
        {
            if (!Component.IsStarted(coroutine))
            {
                throw new ArgumentException("Coroutine hasn't started");
            }

            return Component.GetYield(coroutine);
        }

        public static void Stop(this IEnumerator coroutine)
        {
            if (!Component.IsStarted(coroutine))
            {
                throw new ArgumentException("Coroutine hasn't started");
            }

            Component.StopCoroutine(coroutine);
            Component.StopCoroutine(Component.GetYield(coroutine));
            Component.RemoveCoroutine(coroutine);
        }

        public static bool IsStarted(this IEnumerator coroutine)
        {
            return Component.IsStarted(coroutine);
        }

        private static IEnumerator Remove(IEnumerator coroutine, Coroutine yield)
        {
            yield return yield;
            Component.RemoveCoroutine(coroutine);
        }
    }
}
