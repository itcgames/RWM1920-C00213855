using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ActivateBombTest
    {
        private GameObject m_pressurePlate;
        private GameObject m_player;
        private GameObject m_bomb;

        [SetUp]
        public void Setup()
        {
            m_bomb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bomb"));
            m_player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            m_pressurePlate = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/PressurePlate"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(m_bomb);
            Object.Destroy(m_player);
            Object.Destroy(m_pressurePlate);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ActivateBomb()
        {
            PlayerMovement m_PlayerMovement = m_player.GetComponent<PlayerMovement>();
            CollisionDetection m_pressurePlateCollision = m_pressurePlate.GetComponent<CollisionDetection>();
            BombScript m_bombToActivate = m_bomb.GetComponent<BombScript>();
            m_PlayerMovement.Movement();
            if(m_PlayerMovement.transform.position.x == m_pressurePlate.transform.position.x)
            {
                m_bombToActivate.SetActive(true);
            }

            yield return new WaitForSeconds(0.1f);
            bool result = m_bombToActivate.GetActivate();
            Assert.IsTrue(result);
        }
    }
}
