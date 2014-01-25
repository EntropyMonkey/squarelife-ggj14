using UnityEngine;
using System.Collections;

public class DeathManager : Singleton<DeathManager> {
    private static DeathManager instance;

    private Mortal player = null;
    private Dispatcher<MonoBehaviour>.EventHandler deathHandler = MonoBehaviour => {
        Application.Quit();
    };

    public DeathManager Instance()
    {
        return instance != null ? instance : instance = new DeathManager();
    }

    public Mortal Player
    {
        get
        {
            return player;
        }
        set
        {
            if (player != null)
            {
                player.Killed.RemoveListener(deathHandler);
            }
            player = value;
            value.Killed.AddListener(deathHandler);
        }
    }
}
