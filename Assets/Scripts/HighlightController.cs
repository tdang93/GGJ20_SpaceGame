using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    private GameObject target = null;
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (target) {
            Debug.Log("highlight activated on " + this.target);
            this.transform.position = target.transform.position;
            ps.Play();
        } else {
            ps.Pause();
            ps.Clear();
        }
    }

    public void setTarget(GameObject target) {
        this.target = target;
    }
}
