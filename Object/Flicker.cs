using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour //   밟으면 사라지는 오브젝트

{

    public float timer;
    public float interval;                  //사라지는 속도 조절
    public MeshRenderer mesh;
    public BoxCollider collider;
    public bool active;

    public float startDelay;
    void Update()
    {

        if(this.startDelay > 0)
        {
            this.startDelay -= Time.deltaTime;
            return;

        }

        this.timer += Time.deltaTime;
        if (this.timer > this.interval)
        {

            this.timer = 0;
            this.active = !this.active;
            this.mesh.enabled  = this.active;
            this.collider.enabled = this.active;
        }
    }
}
