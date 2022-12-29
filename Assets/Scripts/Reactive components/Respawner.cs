using UnityEngine;
using Zenject;
using Domain.Movement;
using Domain.Interactions.Triggered;

public class Respawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;

    private MainCharacter _character;
    private IGameStateProvider _provider;

    [Inject]
    public void Initialize(MainCharacter character, IGameStateProvider provider)
    {
        _character = character;
        _provider = provider;
    }

    private void Start()
    {
        _provider.OnStateChanged += x => Respawn();
    }

    public void Respawn()
    {
        _character.gameObject.SetActive(false);
        _character.transform.position = _spawnPosition;
        _character.gameObject.SetActive(true);
        Debug.Log("Character was respawned on position:"+_spawnPosition);
    }

}
