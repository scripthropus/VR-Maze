using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // CameraRigをアサイン
    public float heightOffset = 2f; // プレイヤーからの高さ
    
    void Update()
    {
        transform.position = new Vector3(
            playerTransform.position.x,
            heightOffset, // 固定高さ
            playerTransform.position.z
        );
    }
}