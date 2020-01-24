using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OnPressurePlateTest
    {
        private GameObject m_pressurePlate;
        private GameObject m_player;

        [SetUp]
        public void Setup()
        {
            m_player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            m_pressurePlate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/PressurePlate"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(m_player);
            Object.Destroy(m_pressurePlate);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PressurePlateSteppedOn()
        {
            bool result = false;
            PlayerMovement m_PlayerMovement = m_player.GetComponentInChildren<PlayerMovement>();
            m_PlayerMovement.move();
            yield return new WaitForSeconds(2.0f);
            if(m_player.GetComponent<Transform>().position.x >= m_pressurePlate.GetComponent<Transform>().position.x)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsTrue(result);
        }
    }
}
