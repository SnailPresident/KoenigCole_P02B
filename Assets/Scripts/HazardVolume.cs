using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    public float Damage = .005f;
    private void OnTriggerStay(Collider other)
    {
        PlayerMovement health = other.gameObject.GetComponent<PlayerMovement>();
        if (health != null)
        {
            health.playerHealth -= Damage;
        }
    }
}
