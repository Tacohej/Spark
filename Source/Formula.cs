using System;

public class Formula<T>
{
    public Func<T> calc;

    public Formula(Func<T> calc)
    {
        this.calc = calc;
    }

    public T Value
    {
        get
        {
            return calc.Invoke();
        }
    }
}