namespace EasyReflectionTests
{
    public class OverloadTestClass
    {
        public object ValueFromOverloadedMethod { get; set; }

        public void OverloadedMethod(string str)
        {
            ValueFromOverloadedMethod = str;
        }

        public void OverloadedMethod(int i)
        {
            ValueFromOverloadedMethod = i;
        }
    }
}
