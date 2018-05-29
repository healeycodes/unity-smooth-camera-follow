using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public float moveSmoothTime = 1f; // Lower is slower
    public float heightSmoothTime = 1f; // Lower is slower
    public float rotationSmoothTime = 0.1f; // Lower is slower
    public float followBehindDst = 5f;
    public float lookThisFarInFront = 5f;
    public float height = 12f;
    Vector3 lastPlayerPos;
    Vector3 moveCurrentVelocity;
    float heightCurrentVelocity;

    // Use this for initialization
    void Start () {
        lastPlayerPos = player.transform.position;
    }
	
	// Physics Update
	void FixedUpdate () {

        // This allows the player to be removed from the scene without breaking this script
        if (player != null)
        {
            lastPlayerPos = player.transform.position;
        }

                /* ### Movement ### */

        // X- and Z-axis smooth follow
        Vector3 moveSmoothed = Vector3.SmoothDamp(transform.position, lastPlayerPos - Vector3.back * -followBehindDst, ref moveCurrentVelocity, moveSmoothTime);

        // Y-axis smooth follow
        float heightSmoothed = Mathf.SmoothDamp(transform.position.y, height, ref heightCurrentVelocity, heightSmoothTime);

        // Apply X-,Y-,Z-axis smoothing
        transform.position = new Vector3(moveSmoothed.x, heightSmoothed, moveSmoothed.z);


                /* ### Rotation ### */
        
        // Find the point we are rotating around
        Vector3 toTarget = (lastPlayerPos + Vector3.back * lookThisFarInFront) - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toTarget);

        // Find and apply a lerped rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmoothTime);
    }
}
