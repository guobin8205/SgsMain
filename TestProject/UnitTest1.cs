namespace TestProject
{
    [TestClass]
    public class AwaitTest
    {
        [TestMethod]
        public async void TestMethod1()
        {
            for (int i = 0; i < 5; i++)
            {
                var v = await asyncMethod(i);
                Console.WriteLine(v);
            }
        }

        public static async Task<int> asyncMethod(int i)
        {
            return await Task.Run(() => Add(i));
        }
        static int Add(int i)
        {
            return 1 + 1;
        }
    }
}