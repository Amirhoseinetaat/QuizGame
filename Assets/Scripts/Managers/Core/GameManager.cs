using GameWarriors.DependencyInjection.Attributes;
using GameWarriors.DependencyInjection.Core;
using GameWarriors.DependencyInjection.Extensions;
using GameWarriors.EventDomain.Abstraction;
using GameWarriors.EventDomain.Core;
using GameWarriors.PoolDomain.Abstraction;
using GameWarriors.PoolDomain.Core;
using GameWarriors.ResourceDomain.Abstraction;
using GameWarriors.ResourceDomain.Core;
using GameWarriors.TaskDomain.Abstraction;
using GameWarriors.TaskDomain.Core;
using GameWarriors.UIDomain.Abstraction;
using GameWarriors.UIDomain.Core;
using Managers.Abstraction;
using Managers.Core;
using Services.Abstraction;
using Services.Core.App; 
using System;
using UnityEngine;

namespace Managers
{

    public class GameManager : MonoBehaviour
    {
        public const string INIT_METHOD_NAME = "Initialization";
        [SerializeField]
        private GameObject _splash;

        [Inject]
        private IServiceProvider ServiceProvider { get; set; }

        private void Awake()
        {
            ServiceCollectionEnumerator serviceCollection = new ServiceCollectionEnumerator(INIT_METHOD_NAME);
            serviceCollection.AddSingleton<GameManager>(this);
            serviceCollection.AddSingleton<IEvent, EventSystem>();

            serviceCollection.AddSingleton<IScreen, UISystem>();
            serviceCollection.AddSingleton<IToast, UISystem>();
            serviceCollection.AddSingleton<IAspectRatio, UISystem>();

            serviceCollection.AddSingleton<IPool, PoolSystem>();

            serviceCollection.AddSingleton<ITaskRunner, TaskSystem>();
            serviceCollection.AddSingleton<IUpdateTask, TaskSystem>();

            UIManager uiManager = GetComponent<UIManager>();
            serviceCollection.AddSingleton<IUIEventHandler, UIManager>(uiManager);

            serviceCollection.AddSingleton<IResourceConfig, GameConfig>();
            serviceCollection.AddSingleton<IVariableDatabase, ResourceSystem>();
            serviceCollection.AddSingleton<IContentDatabase, ResourceSystem>();
            serviceCollection.AddSingleton<ISpriteDatabase, ResourceSystem>();
            serviceCollection.AddSingleton<IPlaylist, JSONReaderService>();
            serviceCollection.AddSingleton<IAppService, AppService>();
            serviceCollection.AddSingleton<IPlayAudio, AudioManager>();
            StartCoroutine(serviceCollection.Build(Startup));
        }

        private void Startup()
        {
            IUpdateTask updateTask = ServiceProvider.GetService<IUpdateTask>();
            updateTask.EnableUpdate();
            Destroy(_splash);
            IEvent @event = ServiceProvider.GetService<IEvent>();
            @event.BroadcastInitializeEvent(ServiceProvider);
        }
    }
}