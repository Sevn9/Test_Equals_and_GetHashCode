using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Equals_and_GetHashCode;

namespace TestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
		public void User1_m1_Equals_m2_TrueReturned()
		{
			// arrange

			User1 m1 = new User1("Alice", 18);
			User1 m2 = new User1("Alice", 18);

			// act
			var res1 = m1.Equals(m2);
			
			// assert
			Assert.AreEqual(true, res1);
			

		}
		[TestMethod]
		public void User1_m1_GetHashCode_m2_TrueReturned()
		{
			// arrange

			User1 m1 = new User1("Alice", 18);
			User1 m2 = new User1("Alice", 18);
			bool res;

			// act
			var act1 = m1.GetHashCode();
			var act2 = m2.GetHashCode();

			if (act1 == act2)
      {
				res = true;
      }
      else
      {
				res = false;
			}

			// assert
			// ожидаются одинаковые значения HashCode
			Assert.AreEqual(true, res);

		}
		[TestMethod]
		public void User2_b1_Equals_b2_TrueReturned()
		{
			// arrange
			User2 b1 = new User2("Alice", 18);
			User2 b2 = new User2("Alice", 18);

			// act
			var res = b1.Equals(b2);

			// assert
			Assert.AreEqual(true, res);


		}
		public void User3_c1_Equals_c2_falseReturned()
		{
			// arrange
			User3 c1 = new User3("Alice", 18);
			User3 c2 = new User3("Alice", 20);

			// act
			var res = c1.Equals(c2);

			// assert
			Assert.AreEqual(false, res);


		}
	}
}
