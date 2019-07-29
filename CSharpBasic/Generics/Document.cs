using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Document
    {
        public Document(string content, string title)
        {
            Content = content;
            Title = title;
        }

        public string  Title { get;}

        public string Content { get;}
    }
}
