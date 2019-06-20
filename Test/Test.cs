using System;

namespace Test
{
    public class Test
    {
        public void GetId_GetIdUser
        {
            var calc = new GetId();
            int sum = calc.Add(2, 2);
            Assert.AreEqual(4, sum);
        }
    }
}
