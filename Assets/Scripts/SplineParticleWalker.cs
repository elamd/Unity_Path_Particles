using UnityEngine;
using System.Collections;

public class SplineParticleWalker : MonoBehaviour{

    public BezierSpline target;

    void Update() {
        Trail();
    }

    void Trail() {
        ParticleSystem.Particle[] p = new ParticleSystem.Particle[GetComponent<ParticleSystem>().particleCount + 1];
        int l = GetComponent<ParticleSystem>().GetParticles(p);

        int i = 0;
        while (i < l) {

        }
    }

}
