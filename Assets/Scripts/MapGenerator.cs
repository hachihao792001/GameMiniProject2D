using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapPieceInfo
{
    public Vector2 coord;
    public Transform piece;
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform _mapPiecePrefab;
    [SerializeField] float _mapPieceSize;

    List<MapPieceInfo> currentPieces = new List<MapPieceInfo>();

    private void Update()
    {
        List<Vector2> current4PieceCoords = GetPieceCoords(GameController.Instance.Player.transform.position);

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
                newPieceInfo.piece = Instantiate(_mapPiecePrefab, coord * _mapPieceSize, Quaternion.identity);

                currentPieces.Add(newPieceInfo);
            }
        }
    }

    List<Vector2> GetPieceCoords(Vector2 playerPos)
    {
        int kx = Mathf.CeilToInt((playerPos.x - _mapPieceSize / 2) / _mapPieceSize);
        int ky = Mathf.CeilToInt((playerPos.y - _mapPieceSize / 2) / _mapPieceSize);
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
