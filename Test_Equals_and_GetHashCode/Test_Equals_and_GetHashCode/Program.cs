using System;

namespace Test_Equals_and_GetHashCode
{
  //неправильно переопределен GetHashCode
  public class User1
  {
    public string Name { get; set; }
    public decimal Age { get; set; }

    public User1(string name, decimal age)
    {
      Name = name;
      Age = age;
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
        
      User1 m = obj as User1; // возвращает null если объект нельзя привести к типу User1

      if (m == null)
      {
        return false;
      }

      return m.Name == this.Name && m.Age == this.Age;
    }
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }


  //не переопределен Equals
  public class User2
  {
    public string Name { get; set; }
    public decimal Age { get; set; }


    public User2(string name, decimal age)
    {
      Name = name;
      Age = age;
    }
    
    public override int GetHashCode()
    {
      return HashCode.Combine(this.Name, this.Age);
    }
  }
  //неправильно переопределен Equals (не учитывает все поля)
  public class User3
  {
    public string Name { get; set; }
    public decimal Age { get; set; }


    public User3(string name, decimal age)
    {
      Name = name;
      Age = age;
    }
  
    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }
      
      User3 m = obj as User3;

      if (m == null)
      {
        return false;
      }

      return m.Name == this.Name;
    }
   
    public override int GetHashCode()
    {
      return HashCode.Combine(this.Name);
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      User1 m1 = new User1("Alice", 18);
      User1 m2 = new User1("Alice", 18);
      User1 m3 = new User1("Bob", 18);

      Console.WriteLine(m1.Equals(m2)); // ожидается true
      Console.WriteLine(m1.Equals(m3)); // ожидается false

      // ожидаются одинаковые значения
      Console.WriteLine(m1.GetHashCode()); 
      Console.WriteLine(m2.GetHashCode());

      Console.WriteLine("-----------------------------------------");

      User2 b1 = new User2("Alice", 18);
      User2 b2 = new User2("Alice", 18);
      User2 b3 = new User2("Bob", 18);

      Console.WriteLine(b1.Equals(b2)); //ожидается true
      Console.WriteLine(b1.Equals(b3)); //ожидается false

      // ожидаются одинаковые значения
      Console.WriteLine(b1.GetHashCode()); 
      Console.WriteLine(b2.GetHashCode()); 

      Console.WriteLine("-----------------------------------------");

      User3 c1 = new User3("Alice", 18);
      User3 c2 = new User3("Alice", 20);
      User3 c3 = new User3("Bob", 18);

      Console.WriteLine(c1.Equals(c2)); // ожидается false

      Console.WriteLine(c1.Equals(c3)); // ожидается false

      // ожидаются одинаковые значения
      Console.WriteLine(c1.GetHashCode()); 
      Console.WriteLine(c2.GetHashCode());
      Console.ReadLine();
    }
  }
}
