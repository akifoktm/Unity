
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{//Transform:Konum rotasyou ve ölçeði
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
