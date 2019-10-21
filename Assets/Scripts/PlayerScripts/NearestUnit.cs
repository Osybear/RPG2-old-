using UnityEngine;

public class NearestUnit : MonoBehaviour {

    public LayerMask overlapMask;
    public float maxAttackAngle;

    public GameObject Nearest() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, overlapMask);
        float smallestAngle = float.MaxValue;
        GameObject tempObj = null;

        foreach(Collider col in hitColliders) {
            if(col.gameObject == this.gameObject)
                continue;
                
            Vector3 targetDir = col.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if(angle < smallestAngle) {
                tempObj = col.gameObject;
                smallestAngle = angle;
            }
        }
    
        if(smallestAngle < maxAttackAngle)
            return tempObj;
            
        return null;
    }
}