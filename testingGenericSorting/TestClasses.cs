using System;



public class NumberClass
{
    public string userName;
    public int age;
    public float power;

    public NumberClass(string userName, int age, float power)
    {
        this.userName = userName;
        this.age = age;
        this.power = power;
    }
}

public class DateClass
{
    public DateTime date;
    public string catchPhrase;
    public char letter;

    public DateClass(string date, string catchPhrase, char letter)
    {
        this.date = DateTime.Parse(date);
        this.catchPhrase = catchPhrase;
        this.letter = letter;
    }
}
public class FieldPackage
{
    public string variableName;
    public bool isPublic;
    public object variableValue;

    public FieldPackage(string variableName, bool isPublic, object variableValue)
    {
        this.variableName = variableName;
        this.isPublic = isPublic;
        this.variableValue = variableValue;
    }

    public Type GetVariableType()
    {

        return variableValue.GetType();
    }
}
