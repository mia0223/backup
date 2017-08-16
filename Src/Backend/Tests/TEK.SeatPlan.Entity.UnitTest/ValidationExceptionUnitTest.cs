using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.Entity.Validate;
using ValidationException = TEK.SeatPlan.Entity.Validate.ValidationException;

namespace TEK.SeatPlan.Entity.UnitTest
{
   [TestClass]
   public class ValidationExceptionUnitTest
   {

      [TestClass]
      public class GetErrorMessage : ValidationExceptionUnitTest
      {
         [TestMethod]
         public void WhenValidationErrorsIsSet()
         {
            var expected =
               string.Format(
                  "\n\n[entity 1]:{0}-error Message1{0}-error Message 2{0}[entity 2]:{0}-error Message1{0}-error Message 2{0}{0}",
                  Environment.NewLine);
            var validationErrors = CreateValidationErrors();
            var sut = new ValidationException(validationErrors);

            var result = sut.GetErrorMessage();

            Assert.AreEqual(expected, result);
         }

         [TestMethod]
         public void WhenValidationErrorsIsNull()
         {
            var sut = new ValidationException(null);

            var result = sut.GetErrorMessage();

            Assert.AreEqual(string.Empty, result);
         }

         [TestMethod]
         public void WhenValidationErrorsIsEmpty()
         {
            var sut = new ValidationException(new List<ValidationError>());

            var result = sut.GetErrorMessage();

            Assert.AreEqual($"\n\n{Environment.NewLine}", result);
         }

         private List<ValidationError> CreateValidationErrors()
         {
            return new List<ValidationError>
            {
               new ValidationError("entity 1",
                  new List<ValidationResult>
                  {
                     new ValidationResult("error Message1"),
                     new ValidationResult("error Message 2")
                  }),
               new ValidationError("entity 2",
                  new List<ValidationResult>
                  {
                     new ValidationResult("error Message1",new []{"ignored1","ignored2"}),
                     new ValidationResult("error Message 2")
                  })
            };
         }
      }

   }
}
