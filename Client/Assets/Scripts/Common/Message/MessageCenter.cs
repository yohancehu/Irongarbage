using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public delegate void MessageDelegate(IMessage message);
    public class MessageCenter : Singleton<MessageCenter>
    {
        private Dictionary<MessageType, MessageDelegate> _messageDict;
        private Queue<IMessage> _messageQueue;
        public Queue<IMessage> MessageQueue => _messageQueue;
        public static readonly object msgQueueLock = new object();

        public MessageCenter()
        {
            _messageDict = new Dictionary<MessageType, MessageDelegate>();
            _messageQueue = new Queue<IMessage>();
        }

        public void RegisterMsg(MessageType msgType, MessageDelegate callback)
        {
            if (!_messageDict.ContainsKey(msgType))
            {
                _messageDict.Add(msgType, callback);
            }
            else
            {
                 _messageDict[msgType] += callback;
            }
        }
        public void UnregisterMsg(MessageType msgType, MessageDelegate callback)
        {
            if (_messageDict.ContainsKey(msgType))
            {
                _messageDict[msgType] -= callback;
            }
            if(_messageDict[msgType] == null)
            {
                _messageDict.Remove(msgType);
            }
        }

        /// <summary>
        /// 立马响应的广播，会在这一堆栈就执行,这里千万别在子线程执行
        /// </summary>
        /// <param name="message"></param>
        public void BroadcastImmediately(IMessage message)
        {
            if (message == null)
            {
                return;
            }
            MessageDelegate cb = null;
            _messageDict.TryGetValue(message.MessageType, out cb);
            cb?.Invoke(message);
        }

        /// <summary>
        /// 不立马响应的广播，会到下一帧在MessageLoop中执行
        /// </summary>
        /// <param name="message"></param>
        public void Broadcast(IMessage message)
        {
            if (message == null)
            {
                return;
            }
            MessageDelegate cb = null;
            _messageDict.TryGetValue(message.MessageType, out cb);
            if(cb != null)
            {
                lock (msgQueueLock)
                {
                    _messageQueue.Enqueue(message);
                }
            }
        }
    }
}
