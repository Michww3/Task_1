using System.Collections;
namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new Collection();
            var student = new Student("s1");
            var pensioneer = new Pensioneer("p1");
            var pensioneer2 = new Pensioneer("p2");
            var worker = new Worker("w1");

            collection.AddToCollection(student);
            collection.AddToCollection(pensioneer);
            Console.WriteLine(collection.ReturnLast());
            Console.WriteLine(collection.Contains(student));
            //collection.GetForeach();

            foreach (var res in collection)
            {
                Console.WriteLine(res);
            }
        }
    }
}