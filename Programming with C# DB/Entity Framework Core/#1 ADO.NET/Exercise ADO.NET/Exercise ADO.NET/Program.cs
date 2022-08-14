using System;
using System.Data.SqlClient;
using System.Threading.Channels;

namespace Exercise_ADO.NET
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    SqlConnection conn =
        //        new SqlConnection("Server=NASA-PC;Database=MinionsDB;Trusted_Connection=True;");

        //    conn.Open();

        //    using (conn)
        //    {
        //        SqlCommand cmd = new SqlCommand(@"
        //        CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(30) NOT NULL,CountryCode INT FOREIGN KEY REFERENCES Countries(Id))
        //        CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(30) NOT NULL,Age TINYINT NOT NULL,TownId INT FOREIGN KEY REFERENCES Towns(Id))
        //        CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(30) NOT NULL)
        //        CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(30) NOT NULL,EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))
        //        CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),PRIMARY KEY(MinionId,VillainId))", conn);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        static void Main(string[] args)
        {
            SqlConnection conn =
                    new SqlConnection("Server=NASA-PC;Database=SoftUni;Trusted_Connection=True;");
            conn.Open();

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("SELECT DepartmentId,AVG(Salary) FROM Employees GROUP BY DepartmentId", conn);
                SqlDataReader sqldr = cmd.ExecuteReader();
                Console.WriteLine($"DepartmentId  ===> AVG(Salary)");
                while (sqldr.Read())
                {
                    
                    Console.WriteLine($"{sqldr[0]} ==> {sqldr[1]:f2}");
                }
            }
        }
    }
}
