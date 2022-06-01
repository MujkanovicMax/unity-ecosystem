using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{

    bool animatingMovement;
    bool reachedTarget;
    public float moveSpeed = 5;
    public int moveSpeedFactor = 1;
    public float moveArcHeight = 1;
    public int moveArcHeightFactor = 1;
    public float hopDistance = 1;
    public GameObject target;
    private Collider sensor;


    private float hops;
    float moveTime;


    Vector3 moveStartPos;
    Vector3 moveTargetPos;
    Vector3 targetPos;
    Vector3 hopIncrement;

    // Start is called before the first frame update
    void Start()
    {

        moveStartPos = transform.position;
        targetPos = target.transform.position;
        
        
        hops = Mathf.Floor(Vector3.Distance(targetPos,moveStartPos)/hopDistance);
        hopIncrement = (targetPos - moveStartPos)/hops; 
        moveTargetPos = moveStartPos + hopIncrement;
        animatingMovement = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animatingMovement) {
            //AnimateMove();
        }
        else{
            if(reachedTarget == false){
                moveStartPos = transform.position;
                moveTargetPos += hopIncrement;
                /* print(moveTargetPos);
                print(hops); */
                animatingMovement = true;
            }
            else{
                animatingMovement = false;
            }
        }
    }

    void AnimateMove() {

        moveTime = Mathf.Min (1, moveTime + Time.deltaTime * moveSpeed * moveSpeedFactor);
        float height = (1 - 4 * (moveTime - .5f) * (moveTime - .5f)) * moveArcHeight * moveArcHeightFactor;
        transform.position = Vector3.Lerp (moveStartPos, moveTargetPos, moveTime) + Vector3.up * height;

        // Finished moving
        if (moveTime >= 1) {
            animatingMovement = false;
            moveTime = 0;
            if(Vector3.Distance(targetPos,moveTargetPos) < 0.5){
                reachedTarget = true;
            } 
        }
    }

    void calcDistance(){

    }

    void LookForTarget(){

    }

    
    void OnTriggerEnter(Collider other){
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("water")){
            
        }
    }

}


