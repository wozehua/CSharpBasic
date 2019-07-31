using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class DocumentLinkedList
    {
        public DocumentLinkedList(string title, string content, byte priority)
        {
            Title = title;
            Content = content;
            Priority = priority;
        }

        public string Title { get;}

        public string Content { get;}

        public byte Priority { get;}
    }
}
