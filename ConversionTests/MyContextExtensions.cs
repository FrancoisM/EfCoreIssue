using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conversion
{
    internal static class MyContextExtensions
    {
        public static PropertyBuilder<MyProperty> HasObjetIdConversion(this PropertyBuilder<MyProperty> property)
            => property.HasConversion(
                myProperty => (long)myProperty,
                value => (MyProperty)value);
    }
}