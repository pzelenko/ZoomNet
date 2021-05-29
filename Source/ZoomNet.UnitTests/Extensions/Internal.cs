using Newtonsoft.Json.Linq;
using Shouldly;
using System;
using Xunit;

namespace ZoomNet.UnitTests.Utilities
{
	public class InternalTests
	{
		[Fact]
		public void GetProperty_when_property_is_present()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			var property1 = item.GetProperty("aaa", true);
			var property2 = item.GetProperty("aaa", false);

			// Assert
			property1.ShouldNotBeNull();
			property2.ShouldNotBeNull();
		}

		[Fact]
		public void GetProperty_returns_null_when_property_is_missing_and_throwIfMissing_is_false()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			var property = item.GetProperty("zzz", false);

			// Assert
			property.ShouldBeNull();
		}

		[Fact]
		public void GetProperty_throws_when_property_is_missing_and_throwIfMissing_is_true()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			Should.Throw<ArgumentException>(() => item.GetProperty("zzz", true));
		}

		[Fact]
		public void GetPropertyValue_when_property_is_present()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			var property1 = item.GetPropertyValue("aaa", "Default value");
			var property2 = item.GetPropertyValue<string>("aaa");

			// Assert
			property1.ShouldBe("123");
			property2.ShouldBe("123");
		}

		[Fact]
		public void GetPropertyValue_returns_default_value_when_property_is_missing()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			var property = item.GetPropertyValue("zzz", "Default value");

			// Assert
			property.ShouldBe("Default value");
		}

		[Fact]
		public void GetPropertyValue_throws_when_property_is_missing()
		{
			// Arrange
			var item = new JObject()
			{
				{ "aaa", "123" }
			};

			// Act
			Should.Throw<ArgumentException>(() => item.GetPropertyValue<string>("zzz"));
		}
	}
}
