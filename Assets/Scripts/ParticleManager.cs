using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : SingletonMonoBehaviour<ParticleManager>
{
   public List<GameObject> mainGameParticles = new List<GameObject>();

    public enum MainGameParticlesType
    {
        Invalide = -1,
        LidEffect
    }

    public void SetMaiGameParticles(List<GameObject> particles)
    {
        mainGameParticles = particles;
    }

    public void LidEffectPlay(MainGameParticlesType mainGameParticlesType, Vector3 position)
    {
        var effect = Instantiate(mainGameParticles[(int)mainGameParticlesType],
            position, Quaternion.identity);

        effect.SetActive(true);
    }
}
