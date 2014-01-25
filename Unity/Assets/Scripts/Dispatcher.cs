using System.Collections;
using System.Collections.Generic;

public class Dispatcher<EventDataType> {
    public delegate void EventHandler(EventDataType eventData);

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
        foreach (EventHandler handler in handlers)
        {
            handler(eventData);
        }
    }
}
