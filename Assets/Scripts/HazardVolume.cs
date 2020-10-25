using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    [SerializeField] AudioClip hurtSound = null;
    public float Damage = .005f;
    private void OnTriggerStay(Collider other)
    {
        PlayerMovement health = other.gameObject.GetComponent<PlayerMovement>();
        if (health != null)
        {
            AudioHelper.PlayClip2D(hurtSound, .25f);
            health.playerHealth -= Damage;
        }
    }
}
