

using SWLJ;

namespace TableDefines
{
    public class dialogconfig : TableSrc
    {
        public string id;
        public int nextId;
        public string content;
        public int speakerId;
        public int triggerType;
        public int triggerId;
        public string triggerParam;
    }
    public class unitconfig : TableSrc
    {
        public string id;
        public string name;
        public string picture;
    }
}
