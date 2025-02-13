﻿using System;

namespace Eurotorg_trainee.Helpers
{
    public class MessageArgument<T> : EventArgs
    {
        public T Message { get; set; }
        public MessageArgument(T message)
        {
            Message = message;
        }
    }

    public interface IPublisher<T>
    {
        event EventHandler<MessageArgument<T>> OnChange;
        void Notify(T data);
    }

    public class Publisher<T> : IPublisher<T>
    {
        public event EventHandler<MessageArgument<T>> OnChange = delegate { };

        public void Notify(T data)
        {
            MessageArgument<T> message = new MessageArgument<T>(data);
            OnChange.Invoke(this, message);
        }
    }
}
