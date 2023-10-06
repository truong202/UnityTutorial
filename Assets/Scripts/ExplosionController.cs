using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private void Start()
    {
        Sound.Instance.PlaySound("explosion_sound");
    }
    public void EndExplosion()
    {
        Destroy(gameObject);
    }
}
