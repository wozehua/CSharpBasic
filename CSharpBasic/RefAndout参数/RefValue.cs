namespace RefAndout参数
{
    
    public class ReferenceA
    {
        public int X { get; set; }
        //readOnly 只能在初始化时赋值，或者构造函数中赋值。
        public readonly int a = 10;

        public ReferenceA()
        {
            
        }
        public ReferenceA(int value)
        {
            a = value;
        }
    }

    public struct A
    {
        public int X { get; set; }
    }
}
