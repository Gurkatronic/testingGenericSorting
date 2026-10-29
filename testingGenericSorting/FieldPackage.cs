using System;
using System.Collections;
using System.Reflection;



namespace Fieldpackaging
{
    //detta kan ta vilken type som helst och kolla alla fields som finns i den.
    public class FieldUtility
    {
        public static FieldPackage[] GenericFieldNames<T>(T obj)
        {
            FieldInfo[] fieldInfos = obj.GetType().GetFields();
            FieldPackage[] fieldPackage = new FieldPackage[fieldInfos.Length];

            for (int i = 0; i < fieldInfos.Length; i++)
            {
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
    }
}

