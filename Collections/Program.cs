using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Halmazok
            Console.WriteLine("Halmazok:");
            ISet<Student> shs = new HashSet<Student>
            {
                new Student("Anna", "ABC123", 21),
                new Student("Béla", "DEF456", 23),
                new Student("Dénes", "GHI789", 22),
                new Student("Elemér", "JKL123", 22),
                new Student("Cecil", "MNO456", 21),
                new Student("Anna", "HZJ453", 22),
                new Student("Anna", "ABC123", 21)
            };
            Console.WriteLine(string.Join(",", shs));
			
			ISet<Student> sss = new SortedSet<Student>();
			sss.Add(new Student("Anna","ABC123",21));
			sss.Add(new Student("Béla","DEF456",23));
			sss.Add(new Student("Dénes","GHI789",22));
			sss.Add(new Student("Elemér","JKL123",22));
			sss.Add(new Student("Cecil","MNO456",21));
			sss.Add(new Student("Anna","HZJ453",22));
			sss.Add(new Student("Anna","ABC123",21));
            Console.WriteLine(string.Join("," ,sss));

			ISet<Student> sss2 = new SortedSet<Student>(new SortByCodeAndAge());
			sss2.Add(new Student("Anna","ABC123",31));
			sss2.Add(new Student("Anna","HZJ453",22));
            Console.WriteLine(string.Join(",", sss2));
			
			sss2.Clear();
			sss2.Add(new Student("Béla", "CBA321", 26));
			sss2.Add(new Student("Emma", "CBA123", 22));
			if(sss2.Contains(new Student("Béla", "CBA321", 26))){
                Console.WriteLine("Béla tanuló.");
			}else{
                Console.WriteLine("Béla nem tanuló.");
			}
			sss2.Remove(new Student("Béla", "CBA321", 26));
			if(sss2.Contains(new Student("Béla", "CBA321", 26))){
                Console.WriteLine("Béla még tanuló.");
			}else{
                Console.WriteLine("Béla már nem tanuló.");
			}
            Console.WriteLine("Tömbként: " + string.Join("," , (object[])sss2.ToArray()));

            Console.WriteLine(" - - - - - ");

            //Listák
            Console.WriteLine("Listák:");
			//List esetén sok dolgot használhatok. De IList esetén már kevesebbett.
			//Átadási és visszatérési értékként metódusba Interface típust szoktam adni.
			//List viszolnt lehet a metóduson belül, ha értem miért, és SZÜKSÉGES (mert egyszerűsít)
			IList<Student> sl = new List<Student>();

			if(sl.DefaultIfEmpty() == null ){
                Console.WriteLine("Üres lista.");
			}

			sl.Add(new Student("Anna","ABC123",21));
			sl.Add(new Student("Béla","DEF456",23));
			sl.Add(new Student("Cecil","MNO456",21));
			sl.Add(new Student("Anna","HZJ453",22));
			sl.Add(new Student("Anna","ABC123",21));
			Console.WriteLine(string.Join(",", sl));

			int FirstIndex = sl.IndexOf(new Student("Anna", "ABC123", 21));
			////Csak ha list
			//int DuplicateIndex = sl.LastIndexOf(new Student("Anna","ABC123",21));
			//sl[DuplicateIndex] = new Student("Gábor", "CBA321", 26);
			sl[FirstIndex] =  new Student("Gábor", "CBA321", 26); //Ha csak IndexOf van.
			Console.WriteLine("Átrendezve: " + string.Join(",", sl));
			////Comparable elemek rendezése - Csak ha list
			//sl.Sort();
			//Console.WriteLine("Rendezve: " + string.Join(",", sl));
			////Rendezés Comparatorral - Csak ha list
			//sl.Sort(new SortByCodeAndAge());
			//Console.WriteLine("Comparatorral rendezve: " + string.Join(",", sl));
			//Adott elem lekérése
			Console.WriteLine("3. elem: " + sl[3]);
			//Oredrby rendezés
			IList<Student> sortedSl = sl.OrderBy(s => s.Name).
				ThenBy(s => s.Age).ThenBy(s => s.Code).ToList();
            Console.WriteLine("Ordered:" + string.Join(", ", sortedSl));
			//Van insert!
			sl.Insert(sl.IndexOf(new Student("Anna", "ABC123", 21)), new Student("Zoltán", "ZZZ999", 21));
			if (sl.ElementAt(0).Equals(new Student("Anna", "ABC123", 21)))
            {
                Console.WriteLine("Sikertelen beillesztés.");
            }
            else
            {
                Console.WriteLine("Sikeres beillesztés.");
            }
			Console.WriteLine(string.Join(",", sl));

			ICollection<Student> sll = new LinkedList<Student>();
			sll.Add(new Student("Anna","ABC123",21));
			sll.Add(new Student("Béla","DEF456",23));
			sll.Add(new Student("Cecil","MNO456",21));
			sll.Add(new Student("Anna","HZJ453",22));
			sll.Add(new Student("Anna","ABC123",21));
            Console.WriteLine(string.Join(",", sll));

			//Itt van sorted list is, de oda is kell Key!

			Console.WriteLine(" - - - - - ");

            //Táblázatok
            Console.WriteLine("Táblázatok:");
			//Ha IDictionary-t használok, akkor nincs ComntainsValue, de a többi meglelhető mind.
			IDictionary<string, string> translate = new Dictionary<string, string>();
			translate.Add("alma", "apple");
			translate.Add("nagy", "big");
			translate.Add("finom", "delicious");
			Console.WriteLine("Van nagy? " + translate.ContainsKey("nagy"));
            if (translate.ContainsKey("nagy")){
				translate["nagy"] = "huge";
            }
			string output;
            Console.WriteLine("nagy-" + translate.TryGetValue("nagy", out output));
            Console.WriteLine("Nagy angolul: " + output);
            Console.WriteLine("Kulcsok száma: " + translate.Count());
			//if (translate.ContainsValue("apple"))
			//{
			//	Console.WriteLine("Apple is present.");
			//}

			output = "-semmi-";
			bool siker = translate.TryGetValue("kék", out output);
            Console.WriteLine("Kék: " + siker + " " + output);

            //Kiíratás
            Console.WriteLine(" - - A szótár: - - ");
			foreach (var item in translate)
			{
				Console.WriteLine(item.Key + ": " + item.Value);
			}
            Console.WriteLine(" - - - ");

			//Van Hash és Tree Map. Ugyanaz a logika, mint a Set esetében.
			IDictionary<string, IList<Student>> mssl = new SortedDictionary<string, IList<Student>>();
			mssl["Debrecen"] = new List<Student>();
			mssl["Debrecen"].Add(new Student("Anna", "ABC123", 21));
			mssl["Debrecen"].Add(new Student("Béla", "DEF456", 23));

			//Itt ha nem létezik, akkor létrehozom, majd ezt módosítom.
			//Így ha nincs még, akkor is jó.
			IList<Student> value;
			string name = "Szeged";
			if (!mssl.TryGetValue(name, out value))
			{
				value = new List<Student>();
				mssl[name] = value;
			}
			value.Add(new Student("Dénes", "GHI789", 22));
			value.Add(new Student("Elemér", "JKL123", 22));

			//Foreach bejérás var segítségével
			foreach (var item in mssl)
			{
				Console.WriteLine(item.Key + ": " + string.Join(", ", item.Value));
			}
		}
    }
}
