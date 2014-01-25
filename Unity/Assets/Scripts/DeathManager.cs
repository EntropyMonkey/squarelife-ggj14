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
            Debug.Log("DeathManager: Switching player from " + (player != null ? player.ToString() : "null") + " to " + (value != null ? value.ToString() : "null"));
            if (player != null)
            {
                player.Killed.RemoveListener(deathHandler);
            }
            player = value;
            if (value != null)
            {
                value.Killed.AddListener(deathHandler);
            }
        }
    }
}
