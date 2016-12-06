using UnityEngine;
using System.Collections.Generic;

public class TextureDivider : MonoBehaviour
{
    /// <summary>
    /// The texture to be divided into pieces.
    /// </summary>
    [Tooltip("The texture which will be divided.")]
    [SerializeField] private Texture2D _source;
    /// <summary>
    /// The parent of all inactive puzzlepieces.
    /// </summary>
    [Space(UIManager._SPACE)]
    [Tooltip("Which gameobject will be the parent of the inactive puzzlepieces?")]
    [SerializeField] private Transform _puzzle;
    /// <summary>
    /// The gameobject which holds all spawnpoints.
    /// </summary>
    [Tooltip("The gameobject which holds all spawnpoints.")]
    [SerializeField] private Transform _spawnParent;
    /// <summary>
    /// The amount of rows in the puzzle.
    /// </summary>
    [Space(UIManager._SPACE)]
    [Tooltip("The amount of rows in the puzzle.")]
    [SerializeField] private byte _rows;
    /// <summary>
    /// The amount of columns in the puzzle.
    /// </summary>
    [Tooltip("The amount of columns in the puzzle.")]
    [SerializeField] private byte _cols;

    /// <summary>
    /// Contains all the places where a puzzle piece will be instantiated.
    /// </summary>
    private GameObject[] _spawnPoints;
    /// <summary>
    /// Contains all the instantiated puzzle pieces.
    /// </summary>
    private List<GameObject> _puzzlePieces = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        // get all the spawnpoints from the spawncontainer
        _spawnPoints = GameObject.FindGameObjectsWithTag(Collections.Tags.SpawnPoint.ToString());

        BuildPieces();
    }

    /// <summary>
    /// Makes the pieces of the puzzle based on the given parameters.
    /// </summary>
    private void BuildPieces()
    {
        // compute the width and height of one tile
        short x = (short)(_source.width / _cols), y = (short)(_source.height / _rows);

        // foreach col and row we want to generate a tile of the texture
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                // create a new sprite equal to the width and height of one tile
                // and multiply it by the current index of cols and rows to get the correct positions in the image
                Sprite newSprite = Sprite.Create(_source, new Rect(j * x, i * y, x, y), new Vector2(0.5f, 0.5f));

                // add the sprite to a new gameobject
                GameObject go = new GameObject();
                SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite;

                // set the name and tag of the new gameobject
                go.name = "Puzzelstuk";
                go.transform.tag = Collections.Tags.PuzzlePiece.ToString();
                go.transform.SetParent(_puzzle);

                // add it to the list of puzzlepieces
                _puzzlePieces.Add(go);
            }
        }

        InstantiatePieces();
    }

    /// <summary>
    /// Instantiates all the cut pieces into the scene.
    /// </summary>
    private void InstantiatePieces()
    {
        byte l = (byte)_puzzlePieces.Count;

        for (byte i = 0; i < l; i++)
        {
            // instantiate the piece in the scene
            GameObject obj = (GameObject)Instantiate(_puzzlePieces[i], _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation);
            obj.name = "Puzzelstuk";
            obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            // set it's parent to be the current spawnpoint
            // and give the piece the rotation of the spawnpoint
            obj.transform.SetParent(_spawnPoints[i].transform, true);

            // Make it an item the user can interact with
            // and give it a mass
            obj.AddComponent(typeof(Item));
            obj.AddComponent(typeof(BoxCollider));
            obj.GetComponent<Rigidbody>().mass = 2.3f;

            GameObject interactingPoint = new GameObject(Collections.Tags.InteractionPoint.ToString());
            interactingPoint.transform.SetParent(obj.transform, false);
        }
    }
}