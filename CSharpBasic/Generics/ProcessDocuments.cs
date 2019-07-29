using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    /// <summary>
    /// ProcessDocuments类在一个单独的任务中处理队列中的文档。
    /// 能从外部访问的唯一方法是Start()。
    /// 在Start()方法中，实例化了一个新任务。创建一个ProcessDocuments对象，来启动任务，定义Run()方法作
    /// 为任务的启动方法。
    /// TaskFactory（通过Task类的静态属性Factory访问）的StartNew方法需要一个Action
    /// 委托作为参数，用于接受Run方法传递的地址。TaskFactory的StartNew方法会立即启动任务。
    /// </summary>
    public class ProcessDocuments
    {
        private DocumentManager _document;
        public static void Start(DocumentManager dm)
        {
            Task.Run(new ProcessDocuments(dm).Run);
        }

        public ProcessDocuments(DocumentManager document)
        {
            _document = document ?? throw new ArgumentNullException(nameof(document));
        }

        protected async Task Run()
        {
            while (true)
            {
                if (_document.IsDocumentAvailable)
                {
                    var doc=_document.GetDocument();
                    Console.WriteLine("Processing document {0}",doc.Title);
                }
                await Task.Delay(new Random().Next(20));
            }
            
        }
    }
}
