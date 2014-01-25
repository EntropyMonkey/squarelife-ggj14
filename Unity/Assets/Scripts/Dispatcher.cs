using System.Collections;
using System.Collections.Generic;

public class Dispatcher<EventDataType> {
    public delegate bool EventHandler(EventDataType eventData);

    private HashSet<EventHandler> handlers = new HashSet<EventHandler>();

    public bool AddListener(EventHandler handler)
    {
        return handlers.Add(handler);
    }

    public bool RemoveListener(EventHandler handler)
    {
        return handlers.Remove(handler);
    }

    public void Dispatch(EventDataType eventData)
    {
        HashSet<EventHandler> toBeRemoved = new HashSet<EventHandler>();
        foreach (EventHandler handler in handlers)
        {
            if (handler(eventData))
            {
                toBeRemoved.Add(handler);
            }
        }
        foreach (EventHandler handler in toBeRemoved)
        {
            handlers.Remove(handler);
        }
    }
}
