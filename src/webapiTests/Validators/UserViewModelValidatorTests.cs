using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.Results;
using webapi.ViewModels.Users;
using FluentAssertions;

namespace webapi.Validators.Tests
{
    [TestClass()]
    public class UserViewModelValidatorTests
    {
        [TestMethod()]
        public void UserViewModelValidatorTest()
        {
            var user = new UserViewModel("123456789012345678901", "abc", "123");
            var validator = new UserViewModelValidator();

            // Execute the validator
            ValidationResult results = validator.Validate(user);

            // Inspect any validation failures.
            bool success = results.IsValid;
            List<ValidationFailure> failures = results.Errors;
            var propertyGroups = failures.GroupBy(x => x.PropertyName, x => x);
            var propertyErrorData = propertyGroups.ToDictionary(x => x.Key, x => x.Select(s => s.ErrorMessage));

            var expectedErrorData = new Dictionary<string, List<string>>
            {
                { "UserName", new List<string>() { "帳號長度需小於20字元" } }
            };

            //Assert.AreEqual(success, false);
            success.Should().BeFalse();
            propertyErrorData.Should().BeEquivalentTo(expectedErrorData);
        }
    }
}