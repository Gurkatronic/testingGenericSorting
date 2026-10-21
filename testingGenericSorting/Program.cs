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

            public Class1(string userName, int age, float power) {
                this.userName = userName;
                this.age = age;
                this.power = power;
            }
        }

        public class Class2 {
            public DateTime date;
            public string catchPhrase;

            public Class2(string date, string catchPhrase) {
                this.date = DateTime.Parse(date);
                this.catchPhrase = catchPhrase;
            }
        }


        static FieldPackage[] GenericFieldNames<T>(T obj) { //detta kan ta vilken type som helst och kolla alla fields som finns i den.
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
        static void Main(string[] args) {

            Class1[] Class1s = new Class1[8];
            Class2[] Class2s = new Class2[8];
            #region defining the classes hardcoded style
            Class1s[0] = new("test1", 10,   55f);
            Class1s[1] = new("test2", 440,  25f);
            Class1s[2] = new("test3", 20,   51f);
            Class1s[3] = new("abc",   10,     545f);
            Class1s[4] = new("aba", 30,     35f);
            Class1s[5] = new("aca", 44,     65f);
            Class1s[6] = new("st2", 40,     5f);
            Class1s[7] = new("uuo", 10,     15f);

            Class2s[0] = new("1910-10-01", "Yippie-ki-yay, motherf*****!");
            Class2s[1] = new("1211-10-01", "hasta la vista, baby");
            Class2s[2] = new("1810-10-01", "this is sparta");
            Class2s[3] = new("1230-3-01", "You shall not pass!");
            Class2s[4] = new("2120-10-22", "i'll be back");
            Class2s[5] = new("1220-10-01", "say hello to my little friend");
            Class2s[6] = new("1330-2-11", "may the force be with you");
            Class2s[7] = new("1180-03-01", "Here’s Johnny!");
            #endregion

            InsertionSort(Class1s, 2, false);
            InsertionSort(Class2s, 1, false);

            for (int i = 0; i < Class1s.Length; i++) {
                Console.WriteLine($"{Class1s[i].userName}\t - {Class1s[i].age}\t - {Class1s[i].power}");
            }

            for(int i = 0; i < Class2s.Length; i++) {
                Console.WriteLine($"{Class2s[i].date.ToString()}\t - {Class2s[i].catchPhrase}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Sort a class array based on the value of a variable.
        /// </summary>
        /// <typeparam name="T">The class</typeparam>
        /// <param name="classArray">an array of the class</param>
        /// <param name="fieldPos">the position of the variable inside the variable, if this is over the amount of variables it will crash.</param>
        /// <param name="topFirst">Default is true which will place the highest value on top.</param>
        public static void InsertionSort<T>(T[] classArray, int fieldPos, bool topFirst = true) {
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
    }
}
    

