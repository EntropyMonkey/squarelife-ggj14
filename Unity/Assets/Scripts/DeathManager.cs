using UnityEngine;
using System.Collections;

public class DeathManager {
    private static DeathManager instance;
    public static DeathManager Instance()
    {
        return instance != null ? instance : instance = new DeathManager();
    }

    private Dispatcher<MonoBehaviour>.EventHandler deathHandler = eventData =>
    {
        Debug.Log("Player was killed by " + eventData);
        Application.Quit();
        return true;
    };
    private Mortal player = null;

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
