using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("カメラ")]
    [SerializeField] private Camera firstPersonCamera; // 一人称カメラ
    [SerializeField] private Camera overheadCamera;    // 俯瞰カメラ

    [Header("切り替えキー")]
    [SerializeField] private KeyCode switchKey = KeyCode.M; // Mキーで切り替え

    private bool isOverhead = false;

    void Start()
    {
        // 最初は一人称
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            isOverhead = !isOverhead;

            firstPersonCamera.enabled = !isOverhead;
            overheadCamera.enabled = isOverhead;
        }
    }
}