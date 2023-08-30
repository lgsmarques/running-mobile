using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;
    public List<LevelPieceBase> levelPieces;
    public int piecesStartNumber = 3;
    public int piecesEndNumber = 1;
    public int piecesNumber = 5;

    private int _index;
    private GameObject _currentLevel;
    private List<LevelPieceBase> _spawnedPieces;

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPieces()
    {
        _spawnedPieces = new();

        for (int i = 0; i < piecesStartNumber; i++)
        {
            CreateLevelPiece(levelPiecesStart);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }

        for (int i = 0; i < piecesEndNumber; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
        }
    }

    private void CreateLevelPiece(List<LevelPieceBase> pieces)
    {
        var piece = pieces[Random.Range(0, pieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    //IEnumerator CreateLevelPiecesCoroutine()
    //{
    //    _spawnedPieces = new();

    //    for (int i = 0; i < piecesNumber; i++)
    //    {
    //        CreateLevelPiece();
    //        yield return new WaitForSeconds(timeBeteweenPieces);
    //    }
    //}
}
