using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Collection: IEnumerable
    {
        public ArrayList arrayList = new ArrayList();

        public int AddToCollection(Resident res)
        {
            if (res is Pensioneer)
            {
                int lastIndexPensioneer = arrayList.LastIndexOf(res);
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


        //public void GetForeach()
        //{
        //    foreach (Resident res in arrayList)
        //    {
        //        Console.WriteLine($"{res} {res.PassNum}");
        //    }
        //}

    }
}
