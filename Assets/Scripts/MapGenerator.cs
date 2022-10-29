using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StageMapPiecePrefab
{
    public Stage stage;
    public Transform prefab;
    public float mapPieceSize;
}

public struct MapPieceInfo
{
    public Vector2 coord;
    public Transform piece;
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] List<StageMapPiecePrefab> _stageMapPiecePrefabs;

    List<MapPieceInfo> currentPieces = new List<MapPieceInfo>();

    StageMapPiecePrefab currentStageMapPiecePrefab;

    private void Start()
    {
        currentStageMapPiecePrefab = _stageMapPiecePrefabs.Find(x => x.stage == GameController.Instance.currentStage);
    }

    private void Update()
    {
        List<Vector2> current4PieceCoords = GetPieceCoords(GameController.Instance.Player.transform.position, currentStageMapPiecePrefab.mapPieceSize);

        List<MapPieceInfo> shouldBeRemovedPieces = currentPieces.FindAll(x => !current4PieceCoords.Contains(x.coord));
        foreach (MapPieceInfo pieceInfo in shouldBeRemovedPieces)
        {
            currentPieces.Remove(pieceInfo);
            Destroy(pieceInfo.piece.gameObject);
        }

        foreach (Vector2 coord in current4PieceCoords)
        {
            if (!currentPieces.Exists(x => x.coord == coord))
            {
                MapPieceInfo newPieceInfo;
                newPieceInfo.coord = coord;
                newPieceInfo.piece = Instantiate(currentStageMapPiecePrefab.prefab, coord * currentStageMapPiecePrefab.mapPieceSize, Quaternion.identity);

                currentPieces.Add(newPieceInfo);
            }
        }
    }

    List<Vector2> GetPieceCoords(Vector2 playerPos, float mapPieceSize)
    {
        int kx = Mathf.CeilToInt((playerPos.x - mapPieceSize / 2) / mapPieceSize);
        int ky = Mathf.CeilToInt((playerPos.y - mapPieceSize / 2) / mapPieceSize);
        List<Vector2> result = new List<Vector2>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                result.Add(new Vector2(kx + j, ky + i));
            }
        }

        return result;
    }
}
