using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEK.SeatPlan.Tests.Shared
{
   public static class DtoGenericUtils
   {
      // create the dto with default values: name of the property for string, 1 for decimal
      public static T CreateNewInstanceWithDefaultValues<T>() where T : new()
      {
         var dto = new T();

         foreach (var property in typeof(T).GetProperties())
         {
            if (property.PropertyType == typeof(int))
            {
               property.SetValue(dto, property.Name.GetHashCode());
            }
            else if (property.PropertyType == typeof(string))
            {
               property.SetValue(dto, property.Name);
            }
         }
         return dto;
      }

      public static T CreateNewInstanceWithDefaultValues<T>(Action<T> action) where T : new()
      {
         var dto = CreateNewInstanceWithDefaultValues<T>();
         action(dto);
         return dto;
      }

      public static bool IsEqual<TSource,TDestination>(TSource mappingSource, TDestination mappingDestination,params string[] ignoredMembers)
      {
         var destinationProperties = typeof(TDestination).GetProperties().ToList();
         var checkedProperties = typeof(TSource).GetProperties()
            .Where(property=> !ignoredMembers.Contains(property.Name))
            .Where(property => destinationProperties.Select(p => p.Name).Contains(property.Name));

         foreach (
            var property in checkedProperties)
         {
            if (!ValidateType(property.PropertyType))
               continue;
            var d1Value = GetStringValue(property, mappingSource);
            var d2Value = GetStringValue(destinationProperties.Single(p => p.Name == property.Name), mappingDestination);
               Assert.AreEqual(d1Value, d2Value,
                  $"{typeof(TSource).Name}.{property.Name} member is not the same in both objects");
         }
         return true;
      }


      private static bool ValidateType(Type type)
      {
         //Because ToString() is used, only support Primitive types (int, double, etc) enums, decimals and strings
         //this constraint could be less stringent if ToString() provides proper content value conversion
         return type.IsPrimitive ||
                type.IsEnum ||
                type == typeof(int) ||
                type == typeof(string);
      }

      private static string GetStringValue<T>(PropertyInfo property, T dto)
      {
         var propertyAsObject = property.GetValue(dto);
         var stringValue = propertyAsObject?.ToString() ?? string.Empty;
         return stringValue;
      }

   }
}
