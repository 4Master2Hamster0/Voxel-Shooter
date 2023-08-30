using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Book", menuName = "ScriptableObjects/Book", order = 0)]
public class BookSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Vector2 _scale;
    [SerializeField] private BookType _bookType;

    public Sprite Sprite => _sprite;
    public Vector2 Scale => _scale;
    public BookType Booktype => _bookType;
    
}
