using System;
using System.Collections;
using Tempus.CoroutineTools;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        private void Awake()
        {
            TestMethod().Start();
        }

        private IEnumerator TestMethod()
        {
            Debug.Log("0");
            yield return Yield.Seconds(1f);
            Debug.Log("1");
            yield return Yield.Seconds(1f);
            Debug.Log("2");
        }
    }
}