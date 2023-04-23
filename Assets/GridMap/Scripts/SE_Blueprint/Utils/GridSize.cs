public class GridSize {
    private float InternalValue { get; set; }

    public enum Enum{
        Large, Small
    }

    public static readonly float Small = 0.5f;
    public static readonly float Large = 2.5f;

    public override bool Equals(object obj)
    {
        GridSize otherObj = (GridSize)obj;
        return otherObj.InternalValue.Equals(this.InternalValue);
    }

    public static bool operator >(GridSize left, GridSize right)
    {
        return (left.InternalValue > right.InternalValue);
    }

    public static bool operator <(GridSize left, GridSize right)
    {
        return (left.InternalValue < right.InternalValue);
    }

    public static implicit operator GridSize(float otherType)
    {
        return new GridSize
        {
            InternalValue = otherType
        };
    }

    public static implicit operator float(GridSize otherType)
    {
        return otherType.InternalValue;
    }

    public static implicit operator Enum(GridSize otherType)
    {
        return otherType.InternalValue == Large ? Enum.Large : Enum.Small;
    }

    public static implicit operator GridSize(Enum otherType)
    {
        return otherType == Enum.Large ? GridSize.Large : GridSize.Small;
    }

    public override int GetHashCode()
    {
        return InternalValue.GetHashCode();
    }
}