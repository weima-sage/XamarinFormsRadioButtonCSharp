using System.ComponentModel;
using System;

public static class PropertyEventHandlerExtentions
{
    public static void Handle<T>(
        this PropertyChangedEventHandler handler, T source, String name) where T:INotifyPropertyChanged
    {
        //make a local copy
        var localHandler = handler;
        if(localHandler != null )
        {
            localHandler(source, new PropertyChangedEventArgs(name));
        }
    }
}
