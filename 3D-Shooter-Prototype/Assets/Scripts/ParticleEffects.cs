using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    [Header("粒子效果")]
    public ParticleSystem shootEffect;
    public ParticleSystem explosionEffect;
    public ParticleSystem enemyDeathEffect;
    
    public void PlayShootEffect(Vector3 position)
    {
        if (shootEffect != null)
        {
            ParticleSystem effect = Instantiate(shootEffect, position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
    
    public void PlayExplosionEffect(Vector3 position)
    {
        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
    
    public void PlayEnemyDeathEffect(Vector3 position)
    {
        if (enemyDeathEffect != null)
        {
            ParticleSystem effect = Instantiate(enemyDeathEffect, position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
}