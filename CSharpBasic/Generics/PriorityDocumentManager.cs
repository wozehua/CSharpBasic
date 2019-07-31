using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class PriorityDocumentManager
    {
        private readonly LinkedList<DocumentLinkedList> _documentLinkedLists;
        private readonly List<LinkedListNode<DocumentLinkedList>> _priorityNode;
        public PriorityDocumentManager()
        {
            _documentLinkedLists = new LinkedList<DocumentLinkedList>();
            
            _priorityNode = new List<LinkedListNode<DocumentLinkedList>>(10);
            for (int i = 0; i < 10; i++)
            {
                _priorityNode.Add(new LinkedListNode<DocumentLinkedList>(null));
            }
        }

        public void AddDocument(DocumentLinkedList document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            AddDocumentToPriorityNode(document, document.Priority);
        }

        private void AddDocumentToPriorityNode(DocumentLinkedList document, int priority)
        {
            if (priority > 9 || priority < 0)
                throw new ArgumentException("Priority must be Between 0 and 9");
            if (_priorityNode[priority].Value == null)
            {
                --priority;
                if (priority <= 0)
                {
                    //AddDocumentToPriorityNode(document, priority);
                }
                else
                {
                    _documentLinkedLists.AddLast(document);
                    _priorityNode[document.Priority] = _documentLinkedLists.Last;
                }
            }
            else
            {
               LinkedListNode<DocumentLinkedList> prioNode = _priorityNode[priority];
                if (priority == document.Priority)
                {
                    _documentLinkedLists.AddAfter(prioNode, document);
                    _priorityNode[document.Priority] = prioNode.Next;
                }
                else
                {
                    LinkedListNode<DocumentLinkedList> firstNode = prioNode;
                    while (firstNode.Previous!=null&&firstNode.Previous.Value.Priority==prioNode.Value.Priority)
                    {
                        firstNode = prioNode;
                        prioNode = firstNode;
                    }

                    _documentLinkedLists.AddBefore(firstNode, document);
                    _priorityNode[document.Priority] = firstNode.Previous;
                }
            }
        }

        public void DisplayAllNodes()
        {
            foreach (var item in _documentLinkedLists)
            {
                Console.WriteLine($"priority:{item.Priority},title{item.Title}");
            }
        }


        public DocumentLinkedList GetDocument()
        {
            DocumentLinkedList document = _documentLinkedLists.First.Value;
            _documentLinkedLists.RemoveFirst();
            return document;
        }
    }
}
