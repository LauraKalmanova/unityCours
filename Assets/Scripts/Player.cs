using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    [SerializeField] private ExampleScriptableObject _data;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private Spawner spawner;

    private StateManager stateManager;
    private IInputController inputController;
    
    [Inject]
    private void Construct(IInputController controller)
    {
        inputController = controller;
    }

    private void Start()
    {
        stateManager = new StateManager(gameObject, _data, inputController);
    }

    void Update()
    {
        if(inputController.IsFiring)
        {
            var instance = Instantiate(projectilePrefab, transform.position, transform.rotation);
            var projectile = instance.GetComponent<Projectile>();
            projectile.SetDirection(transform.rotation * new Vector3(0, 0, 1));
            projectile.OnHit += OnProjectileHit;
        }

        stateManager.Update();
    }

    private void OnProjectileHit()
    {
        scoreUI.AddScorePoint();
        spawner.EnemyDestroyed();
    }
}
