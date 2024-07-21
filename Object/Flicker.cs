using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour //   ������ ������� ������Ʈ

{

    public float timer;
    public float interval;                  //������� �ӵ� ����
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
