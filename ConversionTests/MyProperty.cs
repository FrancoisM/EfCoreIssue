namespace Conversion
{
    public class MyProperty
    {
        private readonly long _value;
        private MyProperty(long value) => _value = value;
        public static implicit operator long(MyProperty myProperty) => myProperty._value;
        public static explicit operator MyProperty(long objetId) => new MyProperty(objetId);

    }
}