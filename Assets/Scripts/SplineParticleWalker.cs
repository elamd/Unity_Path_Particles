using UnityEngine;
using System.Collections;

public class SplineParticleWalker : MonoBehaviour{

    public BezierSpline spline;
    public float duration;
    private float progress;
    public bool LookForward;
    public SplineWalkerMode mode;
    private bool goingForward = true;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ParticleSystem.Particle[] p = new ParticleSystem.Particle[GetComponent<ParticleSystem>().particleCount + 1];
        int particleCount = GetComponent<ParticleSystem>().GetParticles(p);
        
        for (int i = 0; i < particleCount - 1; i++) {
            if (goingForward) {
                progress += Time.deltaTime / duration;
                if (progress > 1f) {
                    if (mode == SplineWalkerMode.Once) {
                        progress = 1f;
                    }
                    else if (mode == SplineWalkerMode.Loop) {
                        progress -= 1f;
                    }
                    else {
                        progress = 2f - progress;
                        goingForward = false;
                    }
                }
            }
            else {
                progress -= Time.deltaTime / duration;
                if (progress < 0f) {
                    progress = -progress;
                    goingForward = true;
                }
            }

            float unitMeasure = p[i].startLifetime / spline.points.Length;

            if (p[i].lifetime < p[i].startLifetime / spline.points.Length) {
                p[i].velocity = spline.points.Length / p[i].startLifetime * spline.points[spline.points.Length - 1];
            }
        }
        GetComponent<ParticleSystem>().SetParticles(p, particleCount);
    }
   
}
