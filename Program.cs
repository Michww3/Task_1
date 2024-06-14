using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Collection collection = new Collection();
        Student student = new Student { passNum = "s1" };
        Pensioneer pensioneer = new Pensioneer { passNum = "p1" };
        Pensioneer pensioneer2 = new Pensioneer { passNum = "p2" };
        Worker worker = new Worker { passNum = "w1" };

        collection.AddToCollection(student);
        collection.AddToCollection(pensioneer);
        Console.WriteLine(collection.ReturnLast());
        Console.WriteLine(collection.Contains(student));
        collection.GetForeach();

        foreach(var res in collection)
        {
            Console.WriteLine(res);
        }

    }
}



public abstract class Resident
{
    public string passNum;
}

public class Student : Resident;

class Worker : Resident;

class Pensioneer : Resident;

public class Collection : IEnumerable
{
    public ArrayList arrayList = new ArrayList();

    public int AddToCollection(Resident res)
    {
        if (res is Pensioneer)
        { int lastIndexPensioneer = arrayList.LastIndexOf(res);
            if (lastIndexPensioneer == -1)
            {
                arrayList.Insert(0, res);
            }
            else
            {
                arrayList.Insert(lastIndexPensioneer + 1, res);
            }
            return arrayList.LastIndexOf(res) + 1;
        }
        arrayList.Add(res);
        return arrayList.LastIndexOf(res) + 1;

    }

    public void RemoveFromCollection(Resident res)
    {
        if (arrayList.Contains(res))
        {
            arrayList.Remove(res);
        }
        else Console.WriteLine("Resident isnt in collection");
    }

    public void RemoveAtStartCollection()
    {
        if (arrayList.Count > 0)
        {
            arrayList.RemoveAt(0);
        }
        else Console.WriteLine("Collection is empty");
    }

    public (bool, int) Contains(Resident res)
    {
        bool collectionContains = arrayList.Contains(res);
        int index = arrayList.IndexOf(res);
        return (collectionContains, index);
    }

    public (Resident, int) ReturnLast()
    {
        int index = arrayList.Count - 1;
        if (index < 0)
            return (null, index);

        Resident res = (Resident)arrayList[index];
        return (res, index);
    }

    public void Clear()
    {
        arrayList.Clear();
    }

    public IEnumerator GetEnumerator()
    {
        return arrayList.GetEnumerator();
    }


    public void GetForeach()
    {
        foreach (Resident res in arrayList)
        {
            Console.WriteLine($"{res} {res.passNum}");
        }
    }

}

