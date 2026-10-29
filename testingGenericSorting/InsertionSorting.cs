using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Fieldpackaging.FieldUtility;

namespace testingGenericSorting
{
    internal class InsertionSorting
    {

        /// <summary>
        /// Sort a class array based on the value of a variable.
        /// </summary>
        /// <typeparam name="T">The class</typeparam>
        /// <param name="classArray">an array of the class</param>
        /// <param name="fieldPos">the position of the variable inside the variable, if this is over the amount of variables it will crash.</param>
        /// <param name="topFirst">Default is true which will place the highest value on top.</param>
        public static void InsertionSortGetEveryLoop<T>(T[] classArray, int fieldPos, bool topFirst = true)
        {
            if (classArray.Length <= 0)
                return;

            IComparer comparer = Comparer.Default;


            for (int i = 1; i < classArray.Length; i++)
            {
                FieldPackage[] iFields = GenericFieldNames(classArray[i]);

                for (int j = 0; j < i; j++)
                {

                    FieldPackage[] jFields = GenericFieldNames(classArray[j]);

                    if (topFirst)
                    {
                        if (comparer.Compare(iFields[fieldPos].variableValue, jFields[fieldPos].variableValue) > 0)
                        {

                            (classArray[i], classArray[j]) =
                                (classArray[j], classArray[i]);
                        }
                    }
                    else
                    {
                        if (comparer.Compare(iFields[fieldPos].variableValue, jFields[fieldPos].variableValue) < 0)
                        {

                            (classArray[i], classArray[j]) =
                                (classArray[j], classArray[i]);
                        }
                    }
                }

            }
        }

        public static void InsertionSortGetOnce<T>(T[] classArray, int fieldPos, bool topFirst = true)
        {
            if (classArray.Length <= 0)
                return;

            List<FieldPackage[]> fieldPackages = new List<FieldPackage[]>();
            for (int i = 0; i < classArray.Length; i++)
            {
                fieldPackages.Add(GenericFieldNames(classArray[i]));
            }


            IComparer comparer = Comparer.Default;


            for (int i = 1; i < classArray.Length; i++)
            {

                for (int j = 0; j < i; j++)
                {

                    if (topFirst)
                    {
                        if (comparer.Compare(fieldPackages[i][fieldPos].variableValue, fieldPackages[j][fieldPos].variableValue) > 0)
                        {

                            (classArray[i], classArray[j]) =
                            (classArray[j], classArray[i]);
                            (fieldPackages[i], fieldPackages[j]) =
                            (fieldPackages[j], fieldPackages[i]);
                        }
                    }
                    else
                    {
                        if (comparer.Compare(fieldPackages[i][fieldPos].variableValue, fieldPackages[j][fieldPos].variableValue) < 0)
                        {

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
