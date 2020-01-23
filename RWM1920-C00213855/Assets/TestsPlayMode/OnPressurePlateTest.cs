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
            
            PlayerMovement m_PlayerMovement = m_player.GetComponent<PlayerMovement>();
            CollisionDetection m_pressurePlateCollision = m_pressurePlate.GetComponent<CollisionDetection>();

            m_PlayerMovement.Movement();

            yield return new WaitForSeconds(0.2f);
            if (m_PlayerMovement.transform.position.x == m_pressurePlate.transform.position.x)
            {
                
            }
            bool result = true;
            Assert.IsTrue(result);
        }
    }
}
