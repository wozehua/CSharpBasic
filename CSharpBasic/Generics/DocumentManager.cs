using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class DocumentManager
    {
        private readonly Queue<Document> _documents = new Queue<Document>();

        public void AddDocument(Document document)
        {
            //因为多个线程可以同时访问DocumentManager类，所以用lock语句锁定对队列的访问。
            lock(this)
            {
                _documents.Enqueue(document);
            }
        }

        public Document GetDocument()
        {
            Document document;
            lock(this)
            {
                document = _documents.Dequeue();
            }

            return document;
        }

        public bool IsDocumentAvailable =>_documents?.Count>0;
    }
}
