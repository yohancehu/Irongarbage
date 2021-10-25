using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public class MessageLoop : MonoSingleton<MessageLoop>
    {
        //����ÿ֡�������Ϣ�������С��0�Ǿ��ǲ�����
        private int _handleCountPerFrame = -1;
        public int HandleCountPerFrame { get => _handleCountPerFrame; set => _handleCountPerFrame = value; }

        private void Update()
        {
            var queue = MessageCenter.Instance.MessageQueue;
            int count = HandleCountPerFrame;
            if(count < 0)
            {
                count = queue.Count;
            }
            for (int i = 0; i < count; i++)
            {
                if(queue.IsNullOrEmpty())
                {
                    break;
                }
                IMessage message = queue.Dequeue();
                try
                {
                    if(message != null)
                    {
                        lock (MessageCenter.msgQueueLock)
                        {
                            MessageCenter.Instance.BroadcastImmediately(message);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    LogUtil.LogError(e.Message);
                    throw;
                }
            }
        }
    }
}
