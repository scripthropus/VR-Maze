using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeData : MonoBehaviour
{
    private HashSet<Vector2Int> walls = new HashSet<Vector2Int>();

    void Awake()
    {
        // 壁座標を登録（Luaから抽出したもの）
        // 境界の壁
        for (int i = -16; i <= 16; i++)
        {
            walls.Add(new Vector2Int(-16, i));
            walls.Add(new Vector2Int(16, i));
            walls.Add(new Vector2Int(i, -16));
            walls.Add(new Vector2Int(i, 16));
        }

        // 内部の壁（Luaのif文から）
        walls.Add(new Vector2Int(-15, -16));
        walls.Add(new Vector2Int(-7, -16));
        // ... 残り全部（後で追加）
    }

    public bool IsWall(int x, int z)
    {
        return walls.Contains(new Vector2Int(x, z));
    }
}