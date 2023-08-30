using UnityEngine;

[CreateAssetMenu(fileName = "GameDifficulty", menuName = "ScriptableObjects/GameDifficulty", order = 0)]
public class GameDifficultySO : ScriptableObject {
    [SerializeField] private Difficulty _difficulty;

    public Difficulty Difficulty => _difficulty;
    public void SetDifficulty(Difficulty difficulty) => _difficulty = difficulty;
}
