using System.Collections;
using System.Reflection;

namespace testingGenericSorting {
    internal class Program {

        public class FieldPackage {
            public string variableName;
            public bool isPublic;
            public object variableValue;

            public FieldPackage(string variableName, bool isPublic, object variableValue) {
                this.variableName = variableName;
                this.isPublic = isPublic;
                this.variableValue = variableValue;
            }

            public Type GetVariableType() {

                return variableValue.GetType();
            }
        }


        public class Class1 {
            public string userName;
            public int age;
            public float power;

            public Class1() {

            }
            public Class1(string userName, int age, float power) {
                this.userName = userName;
                this.age = age;
                this.power = power;
            }
        }

        public class Class2 {
            public DateTime date;
            public string catchPhrase;
            public char letter;

            public Class2(string date, string catchPhrase, char letter) {
                this.date = DateTime.Parse(date);
                this.catchPhrase = catchPhrase;
                this.letter = letter;
            }
        }

        //detta kan ta vilken type som helst och kolla alla fields som finns i den.
        static FieldPackage[] GenericFieldNames<T>(T obj) { 
            FieldInfo[] fieldInfos = obj.GetType().GetFields();
            FieldPackage[] fieldPackage = new FieldPackage[fieldInfos.Length];

            for (int i = 0; i < fieldInfos.Length; i++) {
                #region Some comments
                //Debug.Log("name of field: " + fieldInfos[i].Name); //variablen namn
                //Debug.Log("is it public: " + fieldInfos[i].IsPublic); // is public
                //Debug.Log("Value of the field: " + fieldInfos[i].GetValue(obj)); //detta ger det faktiska värdet
                //Debug.Log("type of field: " + fieldInfos[i].GetValue(obj).GetType()); //detta ger vilken type fielden har
                #endregion
                fieldPackage[i] = new FieldPackage(fieldInfos[i].Name, fieldInfos[i].IsPublic, fieldInfos[i].GetValue(obj));
            }

            return fieldPackage;
        }

        static Class1[] RandomClass1(int arraySize, int randomSeed) {
            Class1[] outputArray = new Class1[arraySize];
            string[] randomString = new string[] { "abc", "aaw", "wauda", "aspdo", "odpq", "pwapd", "o1oiiadk", "ppqea", "xscaft", "lasdp", "wwarp", "short" };
            //String, number, float
            Random random = new Random(randomSeed);

            for(int i = 0; i < outputArray.Length; i++) {
                outputArray[i] = new(randomString[random.Next(0, randomString.Length)], random.Next(0, 100), random.NextSingle());
            }

            return outputArray;
        }

        static Class2[] RandomClass2(int arraySize, int randomSeed) {
            Class2[] outputArray = new Class2[arraySize];
            string[] randomString = new string[] { "abc", "aaw", "wauda", "aspdo", "odpq", "pwapd", "o1oiiadk", "ppqea", "xscaft", "lasdp", "wwarp", "short" };
            char[] randomChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'w', 'z', 'c', 'd', 's' };
            //Date, string, char
            Random random = new Random(randomSeed);
            
            for(int i = 0; i < arraySize; i++) {
                DateTime newDate = new DateTime();

                newDate = newDate.AddYears(random.Next(1450, 2000));
                newDate = newDate.AddDays(random.Next(1, 20));
                newDate = newDate.AddMonths(random.Next(1, 13));
                outputArray[i] = new Class2(newDate.ToString(), randomString[random.Next(randomString.Length)], randomChars[random.Next(randomChars.Length)]);
            }



            return outputArray;
        }
        static void Main(string[] args) {

            int arraySize = 4000;
            int randomSeed = 100;

            Class1[] class1s = RandomClass1(arraySize, randomSeed);
            Class2[] class2s = RandomClass2(arraySize, randomSeed);
            var timeStopOnce = System.Diagnostics.Stopwatch.StartNew();
            var timeStopLoop = System.Diagnostics.Stopwatch.StartNew();

            timeStopOnce.Start();
            InsertionSortGetOnce(class1s, 1, false);
            InsertionSortGetOnce(class2s, 1, false);
            timeStopOnce.Stop();

            for (int i = 0; i < class1s.Length; i++) {
                Console.WriteLine($"{class1s[i].userName}\t - {class1s[i].age}\t - {class1s[i].power}");
            }

            for(int i = 0; i < class2s.Length; i++) {
                Console.WriteLine($"{class2s[i].date.ToString()}\t - {class2s[i].catchPhrase}");
            }

            Console.WriteLine("Time spent sorting with one get function on fields: " + timeStopOnce.ElapsedMilliseconds + " ms");
            Console.WriteLine("Press any key to test other method");

            class1s = RandomClass1(arraySize, randomSeed);
            class2s = RandomClass2(arraySize, randomSeed);

            timeStopLoop.Start();
            InsertionSortGetEveryLoop(class1s, 1, false);
            InsertionSortGetEveryLoop(class2s, 1, false);
            timeStopLoop.Stop();

            Console.WriteLine("time spent sorting geting types every iteration: " + timeStopLoop.ElapsedMilliseconds + " ms");
            Console.WriteLine("Time spent sorting with one get function on fields: " + timeStopOnce.ElapsedMilliseconds + " ms");
            long diff = timeStopOnce.ElapsedMilliseconds - timeStopLoop.ElapsedMilliseconds;
            Console.WriteLine("Once - Loop = " + diff + " ms");
            Console.WriteLine("array size : " + arraySize);
            Console.WriteLine("Seed: " + randomSeed);
            Console.ReadKey();






            Console.ReadKey();
        }

        /// <summary>
        /// Sort a class array based on the value of a variable.
        /// </summary>
        /// <typeparam name="T">The class</typeparam>
        /// <param name="classArray">an array of the class</param>
        /// <param name="fieldPos">the position of the variable inside the variable, if this is over the amount of variables it will crash.</param>
        /// <param name="topFirst">Default is true which will place the highest value on top.</param>
        public static void InsertionSortGetEveryLoop<T>(T[] classArray, int fieldPos, bool topFirst = true) {
            if (classArray.Length <= 0)
                return;

            IComparer comparer = Comparer.Default;


            for (int i = 1; i < classArray.Length; i++) {
                FieldPackage[] iFields = GenericFieldNames(classArray[i]);

                for (int j = 0; j < i; j++) {

                    FieldPackage[] jFields = GenericFieldNames(classArray[j]);

                    if (topFirst) {
                        if (comparer.Compare(iFields[fieldPos].variableValue, jFields[fieldPos].variableValue) > 0) {

                            (classArray[i], classArray[j]) =
                                (classArray[j], classArray[i]);
                        }
                    }
                    else {
                        if (comparer.Compare(iFields[fieldPos].variableValue, jFields[fieldPos].variableValue) < 0) {

                            (classArray[i], classArray[j]) =
                                (classArray[j], classArray[i]);
                        }
                    }
                }

            }
        }

        public static void InsertionSortGetOnce<T>(T[] classArray, int fieldPos, bool topFirst = true) {
            if (classArray.Length <= 0)
                return;

            List<FieldPackage[]> fieldPackages = new List<FieldPackage[]>();
            for(int i = 0; i < classArray.Length; i++) {
                fieldPackages.Add(GenericFieldNames(classArray[i]));
            }


            IComparer comparer = Comparer.Default;


            for (int i = 1; i < classArray.Length; i++) {

                for (int j = 0; j < i; j++) {

                    if (topFirst) {
                        if (comparer.Compare(fieldPackages[i][fieldPos].variableValue, fieldPackages[j][fieldPos].variableValue) > 0) {

                            (classArray[i], classArray[j]) =
                            (classArray[j], classArray[i]);
                            (fieldPackages[i], fieldPackages[j]) =
                            (fieldPackages[j], fieldPackages[i]);
                        }
                    }
                    else {
                        if (comparer.Compare(fieldPackages[i][fieldPos].variableValue, fieldPackages[j][fieldPos].variableValue) < 0) {

                            (classArray[i], classArray[j]) =
                            (classArray[j], classArray[i]);
                            (fieldPackages[i], fieldPackages[j]) =
                            (fieldPackages[j], fieldPackages[i]);
                        }
                    }
                }

            }
        }
    }
}
    

