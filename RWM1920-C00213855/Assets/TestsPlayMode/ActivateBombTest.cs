using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ActivateBombTest
    {
        private GameObject m_bomb;
        [SetUp]
        public void Setup()
        {
            m_bomb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bomb"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(m_bomb);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ActivateBomb()
        {
            BombScript bombscript = m_bomb.GetComponentInChildren<BombScript>();
            bombscript.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Assert.True(bombscript.GetActivate());
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ExplodeBomb()
        {
            BombScript bombscript = m_bomb.GetComponentInChildren<BombScript>();
            bombscript.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            if(bombscript.GetActivate())
            {
                bombscript.SetExploded(true);
            }
            Assert.True(bombscript.GetExploded());
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SoundPlay()
        {
            BombScript bombscript = m_bomb.GetComponentInChildren<BombScript>();
            AudioSource bombSound = m_bomb.GetComponentInChildren<AudioSource>();
            bombscript.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            if (bombscript.GetActivate())
            {
                bombscript.SetExploded(true);
            }
            if(bombscript.GetExploded())
            {
                bombSound.Play();
            }
            Assert.True(bombSound.isPlaying);
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ParticlePlay()
        {
            BombScript bombscript = m_bomb.GetComponentInChildren<BombScript>();
            ParticleSystem particle = m_bomb.GetComponentInChildren<ParticleSystem>();
            bombscript.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            if (bombscript.GetActivate())
            {
                bombscript.SetExploded(true);
            }
            if (bombscript.GetExploded())
            {
                particle.Play();
            }
            Assert.True(particle.isPlaying);
        }

    }
}
